using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.RequestPayLoad;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : Controller
    {
        private readonly IRepository<ToDoItem> _itemRepository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IRepository<ToDoItem> itemRepository, IMapper mapper)
        {
            this._itemRepository = itemRepository;
            this._mapper = mapper;
        }

        // GET: api/ToDoItems
        [HttpGet("GetAllToDoItems")]
        public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAllTodoItems()
        {
            var result = await _itemRepository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ToDoItems/5
        [HttpGet("GetToDoItem")]
        public async Task<ActionResult<ToDoItemDto>> GetToDoItem([FromRoute] Guid id)
        {
            var result = await _itemRepository.GetById(id);
            return Ok(result);
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("EditTodoitem")]
        public async Task<ActionResult<ToDoItemDto>> EditToDoItem([FromRoute] Guid id, [FromForm] EditToDoItemRequest toDoItem)
        {
            var item = await _itemRepository.GetAllAsQueryable().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            item.ToDoTitle = toDoItem.ToDoTitle;
            item.IsComplete = toDoItem.IsComplete;
            if (toDoItem.IsComplete == true)
            {
                item.CompletionStatus = IsCompleteStatus.Complete.ToString();
            }
            else
            {
                item.CompletionStatus = IsCompleteStatus.InComplete.ToString();
            }
            item.ToDoDescription = toDoItem.ToDoDescription;

            await _itemRepository.Update(item);
            await _itemRepository.Save();

            return Ok(item);
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateTodoitem")]
        public async Task<ActionResult<ToDoItem>> CreateToDoItem([FromBody] ToDoItemRequest toDoItem)
        {

            var result = _mapper.Map<ToDoItem>(toDoItem);

            //result.Id = Guid.NewGuid();
            await _itemRepository.Create(result);
            await _itemRepository.Save();

            return Ok(result);
            //return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
            //return CreatedAtAction(nameof(GetToDoItem), new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("DeleteToDoItem")]
        public async Task<IActionResult> DeleteToDoItem(Guid id)
        {
            var item = await _itemRepository.GetById(id);
            await _itemRepository.Delete(item);
            await _itemRepository.Save();
            return Ok();
        }
    }
}

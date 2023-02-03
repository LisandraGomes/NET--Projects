using ApiTodo.Data;
using ApiTodo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTodo.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("api/searchAll")]
        public List<TodoModels> Get([FromServices] AppDbContext context)
        {
            var todos = context.Todos.ToList();
            return todos;
        }

        [HttpPost]
        [Route("api/RegisterTodo")]
        public TodoModels RegisterTodo(
            [FromBody] TodoModels todo,
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;
        }
        //IActionResult -> tipo especifico do asp para padronizar a api retornando os ranges com informação. 200, 404, 504...
        [HttpGet]
        [Route("api/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound("Tarefa não encontrada!");
            return Ok(todo);
        }

        [HttpPut]
        [Route("api/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModels? todo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x=> x.Id == id);
            if (todo == null) return NotFound("To do não encontrado!");

            if(todo.Title != null && todo.Title.Trim() != "") model.Title = todo.Title;
            if(todo.Description != null && todo.Description.Trim() != "") model.Description = todo.Description;
            if(todo.Done !=null) model.Done = todo.Done;

            context.Update(model);
            context.SaveChanges();

            return Ok(model);

        }

        [HttpDelete]
        [Route("/{id:int}")]
        public TodoModels Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            context.Remove(model);
            context.SaveChanges();
            return model;
        }
    
    }
}

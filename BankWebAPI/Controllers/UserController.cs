using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebAPI.Models;
using BankWebAPI.Services;
using BankWebAPI.ViewModels;

namespace BankWebAPI.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(UserCreateViewModel userCreateViewModel)
        {
            if (await _userService.CheckUserExist(userCreateViewModel))
            {
                ModelState.AddModelError("","Пользователь уже существует");
            }
            var age = DateTime.Now.Year - userCreateViewModel.DateBirth.Year;
            if (age<18||age>100)
            {
                ModelState.AddModelError("","Некорректный возраст"); 
            }

            if (ModelState.IsValid)
            {
                await _userService.CreateAsync(userCreateViewModel);
                return Ok("Пользователь успешно создан");
            }

            return Problem("Пользователь уже существует, или указана некорректная дата рождения");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }
    }
}

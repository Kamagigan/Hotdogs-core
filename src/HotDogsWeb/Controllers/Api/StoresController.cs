using AutoMapper;
using HotDogsWeb.Context;
using HotDogsWeb.Models;
using HotDogsWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDogsWeb.Controllers.api
{
    [Route("api/stores")]
    public class StoresController : Controller
    {
        private IHotDogRepository _repository;
        private ILogger<StoresController> _logger;

        public StoresController(IHotDogRepository repository, ILogger<StoresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var stores = _repository.GetAllStores();

                if (stores != null && stores.Count() > 0)
                {
                    return Ok(Mapper.Map<IEnumerable<HotDogStoreViewModel>>(stores));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to Get All Stores", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStore([FromBody]HotDogStoreViewModel storeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStore = Mapper.Map<HotDogStore>(storeViewModel);

                    _repository.AddStore(newStore);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"api/stores/{newStore.Id}", Mapper.Map<HotDogStoreViewModel>(newStore));
                    }
                    else
                    {
                        return BadRequest("euh.... Savegarde en BDD échoué");
                    }
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to Add Store", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

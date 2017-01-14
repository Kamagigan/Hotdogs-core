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
    [Route("api/stores/{storeId}/hotdogs")]
    public class HotDogController : Controller
    {
        private IHotDogRepository _repository;
        private ILogger<HotDogController> _logger;

        public HotDogController(IHotDogRepository repository, ILogger<HotDogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //[HttpGet("")]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var hotdogs = _repository.GetAll();

        //        if (hotdogs == null || hotdogs.Count() == 0)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(Mapper.Map<IEnumerable<HotDogViewModel>>(hotdogs));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Fail to GetAll HotDogs : {ex}");

        //        return BadRequest("Haha ! Ta requète genere des bugs !");
        //    }
        //}

        public IActionResult GetByStoreId(int storeId)
        {
            try
            {
                if (storeId > 0)
                {
                    var hotdogs = _repository.GetHotDogsByStoreId(storeId);

                    if (hotdogs != null && hotdogs.Count() > 0)
                    {
                        return Ok(Mapper.Map<IEnumerable<HotDogViewModel>>(hotdogs));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest("StoreId doit être superieur à 0");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to get HotDogs for storeId : {storeId}", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(int storeId, [FromBody] HotDogViewModel hotDogViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newHotDog = Mapper.Map<HotDog>(hotDogViewModel);

                    _repository.AddHotDog(storeId, newHotDog);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"api/stores/{newHotDog.HotDogStoreId}/hotdogs/{newHotDog.Id}", 
                            Mapper.Map<HotDogViewModel>(newHotDog));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "euh.... Savegarde en BDD échoué");
                    }
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to Add HotDogs for storeId : {storeId}", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

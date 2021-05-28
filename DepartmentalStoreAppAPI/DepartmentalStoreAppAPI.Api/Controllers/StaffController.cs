using AutoMapper;
using DepartmentalStoreAppAPI.Application.Models;
using DepartmentalStoreAppAPI.Application.RepositoryInterface;
using DepartmentalStoreAppAPI.Domain;
using DepartmentalStoreAppAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public StaffController(IStaffRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet]
        public async Task<ActionResult<StaffModel[]>> Get(bool includeStaffRole = true)       // to use any specific type of return value
        {
            try
            {
                var result = await _repository.GetAllStaffsAsync(includeStaffRole);
                Console.WriteLine("test");
                return _mapper.Map<StaffModel[]>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("{firstname}")]
        public async Task<ActionResult<StaffModel>> Get(string firstname, bool includeStaffRole = true)       // to use any specific type of return value
        {
            try
            {
                var result = await _repository.GetAStaffAsync(firstname, includeStaffRole);

                return _mapper.Map<StaffModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StaffModel>> GetStaffById(int id, bool includeStaffRole = true)
        {
            try
            {
                var result = await _repository.GetAStaffAsyncByID(id, includeStaffRole);

                return _mapper.Map<StaffModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("role/{rolename}")]
        public async Task<ActionResult<StaffModel[]>> SearchByRole(string rolename, bool includeRole = true)
        {
            try
            {
                var results = await _repository.GetAllStaffByRole(rolename, includeRole);

                if (!results.Any()) return NotFound();

                return _mapper.Map<StaffModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost]
        public async Task<ActionResult<StaffModel>> Post(Staff staff)
        {
            try
            {
                _repository.Add(staff);
                if(await _repository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction("Post", "Staff",
                          new {  staff.StaffId }
                          );

                    return Created(url, _mapper.Map<StaffModel>(staff));
                }
                else
                {
                    return BadRequest("Failed to add new Staff");
                }
            
             }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Staff");
            }
        }

        [HttpPut("{staffId}")]
        public async Task<ActionResult<StaffModel>> Put(int staffId, Staff model)
        {
            try
            {
                var staff = await _repository.GetAStaffAsyncByID(staffId, true);
                if (staff == null) return NotFound("Couldn't find the staff");


                //_mapper.Map(model, staff , opt => opt.BeforeMap((s,d)=> s.StaffId = d.StaffId));
                staff = model;
                staff.StaffId = staffId;
                _repository.Update(staff);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<StaffModel>(model);
                }
                else
                {
                    return BadRequest("Failed to update database.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Staff");
            }
            return Ok();
        }

        [HttpDelete("{staffId}")]
        public async Task<IActionResult> Delete(int staffId)
        {
            try
            {
                var staff = await _repository.GetAStaffAsyncByID(staffId);
                if (staff == null) return NotFound("Failed to find the staff to delete");
                _repository.Delete(staff);



                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to delete staff");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Staff");
            }
        }







    }
}
//[HttpGet("test")]
//public ActionResult<StaffModel[]> GetSync()       // to use any specific type of return value
//{

//        var result =  _repository.GetAllStaffsSync();
//        Console.WriteLine("test");
//        return _mapper.Map<StaffModel[]>(result);

//}

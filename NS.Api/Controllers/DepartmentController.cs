using System;
using AutoMapper;
using NS.DTO.Acount;
using NS.Api.Helpers;
using NS.Core.Entities;
using NS.Core.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace NS.Api.Controllers
{
    [Route("api/Department")]
    public class DepartmentController : NSControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _departmentService.GetAll();
            var dataModel = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentModel>>(data);

            return Ok(dataModel);
        }

        [HttpPost]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Post(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Put(int id, DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            await _departmentService.Delete(id);

            return NoContent();
        }
    }
}
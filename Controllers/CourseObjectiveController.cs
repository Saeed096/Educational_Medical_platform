using Educational_Medical_platform.DTO.Objective;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseObjectiveController : ControllerBase
    {
        private readonly ICourseObjectiveRepository _CourseObjectiveRepository;
        private readonly ICourseRepository _CourseRepository;
        public CourseObjectiveController(ICourseObjectiveRepository CourseObjectiveRepository,
            ICourseRepository CourseRepository)
        {
            _CourseObjectiveRepository = CourseObjectiveRepository;
            _CourseRepository = CourseRepository;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            
            List<GetObjectiveDTO> GetObjectivesDTOs = _CourseObjectiveRepository.FindAll().Select(o => new GetObjectiveDTO()
            {
                Id = o.Id,
                CourseId = o.CourseId,
                //Course = o.Course,
                Description = o.Description
            }).ToList();

            if (GetObjectivesDTOs is null || !GetObjectivesDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "There Are no objectives Available."
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = GetObjectivesDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {

            Objective? objective =  _CourseObjectiveRepository.GetById(id);
            if (objective != null)
            {
                GetObjectiveDTO GetObjectiveDTO = new GetObjectiveDTO()
                {
                    Id = id,
                    CourseId = objective.CourseId,
                    //Course = objective.Course,
                    Description = objective.Description
                };
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = GetObjectiveDTO,
                    Message = "Objective retrieved successfully."
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = null,
                Message = "No objective found for this id."
            };
        }

        [HttpPut]
        public ActionResult<GeneralResponse> Edit([FromForm] UpdateObjectiveDTO objective)
        {
            Objective? objectiveFromDB = _CourseObjectiveRepository.GetById(objective.Id);
            if (objectiveFromDB != null)
            {
                if(_CourseRepository.GetById(objective.CourseId) != null)
                {
                    objectiveFromDB.CourseId = objective.CourseId;
                    objectiveFromDB.Description = objective.Description;

                    _CourseObjectiveRepository.Update(objectiveFromDB);
                    _CourseObjectiveRepository.save();
                    GetObjectiveDTO GetObjectiveDTO = new GetObjectiveDTO()
                    {
                        Id= objective.Id,
                        Description = objective.Description,
                        CourseId = objective.CourseId
                    };
                    return new GeneralResponse()
                    {
                        IsSuccess = true,
                        Data = GetObjectiveDTO,
                        Message = "Objective updated successfully."
                    };
                }
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Invalid course id"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = null,
                Message = "No objective found for this id."
            };
        }


        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            Objective? objective = _CourseObjectiveRepository.GetById(id);
            if (objective != null)
            {
                GetObjectiveDTO getObjectiveDTO = new GetObjectiveDTO()
                {
                    Id = objective.Id,
                    Description = objective.Description,
                    CourseId = objective.CourseId
                };

               _CourseObjectiveRepository.Delete(objective);
                _CourseObjectiveRepository.save();
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = getObjectiveDTO,
                    Message = "Objective deleted successfully."
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = null,
                Message = "No objective found for this id."
            };
        }

        [HttpPost]
        public ActionResult<GeneralResponse> Add([FromForm] UpdateObjectiveDTO objective)
        {
            if (_CourseRepository.GetById(objective.CourseId) != null)
            {
                Objective obj = new Objective();
                obj.CourseId = objective.CourseId;
                obj.Description = objective.Description;

                _CourseObjectiveRepository.Add(obj);
                _CourseObjectiveRepository.save();
                GetObjectiveDTO GetObjectiveDTO = new GetObjectiveDTO()
                {
                    Id = obj.Id,
                    Description = obj.Description,
                    CourseId = obj.CourseId
                };
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = GetObjectiveDTO,
                    Message = "Objective added successfully."
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = null,
                Message = "Invalid course id"
            };

        }

    }
}

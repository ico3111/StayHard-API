using Microsoft.AspNetCore.Mvc;
using Application.Domains.Workout.Dtos;
using Application.Domains.Workout.Interfaces;

namespace StayHard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StayHardController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        // O serviço é injetado via construtor
        public StayHardController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public ActionResult<WorkoutDto> GetWorkout()
        {
            var resposta = _workoutService.GetWorkout();
            return Ok(resposta);
        }
    }
}

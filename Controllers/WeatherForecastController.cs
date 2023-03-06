using Microsoft.AspNetCore.Mvc;

namespace ElmaSQLServise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class DBConfigurationController : ControllerBase
    {
        private readonly ILogger<DBConfigurationController> _logger;

        public DBConfigurationController(ILogger<DBConfigurationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDBConfiguration")]
        public OrganisationStructureItem Get()
        {
            var item = OrganisationStructureItem.Create(Guid.NewGuid(), "My Company");
            item.AddHeaderPosition(Guid.NewGuid(), $"ген Директор {item.Name}");
            int DepsLength = Random.Shared.Next(1,1);
            for (int i = 1; i <= DepsLength; i++)
            {   
                int GroupLength = Random.Shared.Next(1,1);
                var dep = item.AddDepartment(Guid.NewGuid(), $"Департамент {i}");
                dep.AddHeaderPosition(Guid.NewGuid(), $"Директор {dep.Name}");

                for (int ii = 1; ii <= GroupLength; ii++)
                {
                    int PositionLength = Random.Shared.Next(1,1);
                    var group = dep.AddGroup(Guid.NewGuid(), $"Группа {ii}");
                    group.AddHeaderPosition(Guid.NewGuid(), $"Руководитель {group.Name}");
                    for (int iii = 1; iii <= PositionLength; iii++)
                    {
                        var position = group.AddPosition(Guid.NewGuid(), $"Должность {iii}");
                    }
                }
            }
            return item;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        // Get all categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(categories);
        }

        // Get category by ID
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // Create a new category
        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            category.Id = categories.Count + 1; // Simple auto-increment
            categories.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // Calcular Scenario I
        [HttpPost("scenarioI")]
        public ActionResult<int> CalculateScenarioI(Category category)
        {
            var scenarioI = CalculateScenarioI(category.TotalComputers, category.ComputersInOfficeC, category.Offices, category.AccessPointsPerOffice);
            return Ok(scenarioI);
        }

        // Calcular Scenario II e a probabilidade
        [HttpPost("scenarioII")]
        public ActionResult<double> CalculateScenarioII(Category category)
        {
            var scenarioI = CalculateScenarioI(category.TotalComputers, category.ComputersInOfficeC, category.Offices, category.AccessPointsPerOffice);
            var scenarioII = CalculateScenarioII(category.TotalComputers, category.ComputersInOfficeC, category.Offices, category.AccessPointsPerOffice);
            var probabilityC = CalculateProbabilityC(scenarioI, scenarioII);
            return Ok(new { ScenarioII = scenarioII, ProbabilityC = probabilityC });
        }

        // Função para calcular o Scenario I
        private int CalculateScenarioI(int totalComputers, int computersInOfficeC, int offices, int accessPointsPerOffice)
        {
            int scenarioI = 0;
            for (int i = 0; i <= offices; i++)
            {
                for (int j = 0; j <= offices; j++)
                {
                    for (int k = 0; k <= offices; k++)
                    {
                        if (i * accessPointsPerOffice + j * accessPointsPerOffice + k * computersInOfficeC == totalComputers)
                        {
                            if (k == 1) // Se o escritório C tem 3 computadores
                            {
                                scenarioI++;
                            }
                        }
                    }
                }
            }
            return scenarioI;
        }

        // Função para calcular o Scenario II
        private int CalculateScenarioII(int totalComputers, int computersInOfficeC, int offices, int accessPointsPerOffice)
        {
            int scenarioII = 0;
            for (int i = 0; i <= offices; i++)
            {
                for (int j = 0; j <= offices; j++)
                {
                    for (int k = 0; k <= offices; k++)
                    {
                        if (i * accessPointsPerOffice + j * 4 + k * 4 == totalComputers)
                        {
                            if (i == 1) // Se o escritório A tem todos os pontos de acesso
                            {
                                scenarioII++;
                            }
                        }
                    }
                }
            }
            return scenarioII;
        }

        // Função para calcular a probabilidade de sobrecarga do escritório C
        private double CalculateProbabilityC(int scenarioI, int scenarioII)
        {
            int totalScenarios = scenarioI + scenarioII;
            if (totalScenarios == 0) return 0; // Evitar divisão por zero
            return (double)scenarioI / totalScenarios * 100;
        }

        // Update an existing category
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            // Atualize os valores principais
            category.TotalComputers = updatedCategory.TotalComputers;
            category.ComputersInOfficeC = updatedCategory.ComputersInOfficeC;
            category.Offices = updatedCategory.Offices;
            category.AccessPointsPerOffice = updatedCategory.AccessPointsPerOffice;

            return NoContent();
        }

        // Delete a category
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            categories.Remove(category);
            return NoContent();
        }
    }
}

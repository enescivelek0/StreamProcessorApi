using Microsoft.AspNetCore.Mvc;
using StreamProcessorApi.Data;
using StreamProcessorApi.Models;
using System.Text;

namespace StreamProcessorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StreamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            var people = new List<Person>();

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    var person = new Person
                    {
                        FirstName = parts[0],
                        LastName = parts[1],
                        Email = parts[2]
                    };
                    people.Add(person);
                    _context.People.Add(person);
                }
            }

            await _context.SaveChangesAsync();

            // CSV oluştur
            var fileName = $"people_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);

            using var writer = new StreamWriter(filePath);
            await writer.WriteLineAsync("FirstName,LastName,Email"); // header
            foreach (var person in people)
            {
                await writer.WriteLineAsync($"{person.FirstName},{person.LastName},{person.Email}");
            }

            return Ok(new
            {
                message = "Veriler kaydedildi ve CSV oluşturuldu.",
                csvFile = $"/files/{fileName}"
            });
        }

    }
}

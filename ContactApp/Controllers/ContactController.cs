using ContactApp.Data;
using ContactApp.Model.Domain;
using ContactApp.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext contactDbContext;
        public ContactController(ContactDbContext contactDbContext)
        {
            this.contactDbContext = contactDbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(contactDbContext.Contacts.ToList());
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO addContactRequestDTO)
        {
            var model = new Contact { Id = new Guid(), Name = addContactRequestDTO.Name, Email = addContactRequestDTO.Email, Phone = addContactRequestDTO.Phone, Favorite = addContactRequestDTO.Favorite };
            contactDbContext.Contacts.Add(model);
            contactDbContext.SaveChanges();
            return Ok(model);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id) {
            var contact = contactDbContext.Contacts.Find(id);
            if(contact is not null)
            {
                contactDbContext.Contacts.Remove(contact);
                contactDbContext.SaveChanges();
            }

            return Ok();
        }
    }
}

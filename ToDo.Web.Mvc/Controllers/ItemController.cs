using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;

namespace ToDo.Web.Mvc.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemAppService _service;
        public ItemController(IItemAppService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _service.GetItemsAsync();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description")] CreateItemRequestDto createItemModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateItemAsync(createItemModel);
                return RedirectToAction(nameof(Index));
            }  

            return View(createItemModel);
        }

        [HttpGet("[action]/{id}")]
        public async Task<RedirectToActionResult> Edit([FromRoute] Guid id, [Bind("done")] Boolean done)
        {
            await _service.UpdateItem(id);
            return RedirectToAction("Index");
        }
        
        [HttpGet("[action]/{id}")]
        public async Task<RedirectToActionResult> Remove([FromRoute] Guid id)
        {
            await _service.RemoveItem(id);
            return RedirectToAction("Index");
        }
    }
}

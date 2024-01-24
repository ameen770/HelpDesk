using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.WebUI.Data;
using HelpDesk.WebUI.Models;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.WebUI.Controllers
{
    public class ClientRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ClientRequestsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ClientRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.clientRequests.Include(c => c.AppUser);

            /*var clientRequests = await applicationDbContext.ToListAsync();

            // Map the ID to the Name for each client request
            foreach (var clientRequest in clientRequests)
            {
                clientRequest.AppUserId = clientRequest.AppUser.UserName;
            }

            return View(clientRequests);*/
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (clientRequest == null)
            {
                return NotFound();
            }

            return View(clientRequest);
        }

        // GET: ClientRequests/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: ClientRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,ClientName,RequestDescription,RequestType,RStatus,RequestDate,ResponseDate,Response,AppUserId,CreatedIn,CreatedBy,ModifiedIn,ModifiedBy")] ClientRequest clientRequest)
        {
            if (ModelState.IsValid)
            {
                clientRequest.RStatus = Enum.RequestStatus.Waiting;
                clientRequest.RequestDate = DateTime.Now;
                var request = new ClientRequest
                {
                    RStatus = clientRequest.RStatus,
                    RequestDate = clientRequest.RequestDate
                };
                _context.Add(clientRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        // GET: ClientRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests.FindAsync(id);
            if (clientRequest == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        // POST: ClientRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,ClientName,RequestDescription,RequestType,RStatus,RequestDate,ResponseDate,Response,AppUserId,CreatedIn,ModifiedIn")] ClientRequest clientRequest)
        {
            if (id != clientRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clientRequest.RStatus = Enum.RequestStatus.Waiting;
                    //clientRequest.RequestDate = DateTime.Now;
                    var request = new ClientRequest
                    {
                        RStatus = clientRequest.RStatus,
                        //RequestDate = clientRequest.RequestDate
                    };
                    _context.Update(clientRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientRequestExists(clientRequest.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        // GET: ClientRequests/Assigned/5
        // [Route("clientrequests/assigned/{id}")]
        public async Task<IActionResult> Assigned(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests.FindAsync(id);
            if (clientRequest == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        // POST: ClientRequests/Assigned/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assigned(int id, [Bind("RequestId,ClientName,RequestDescription,RequestType,RStatus,RequestDate,ResponseDate,Response,AppUserId,CreatedIn,ModifiedIn")] ClientRequest clientRequest)
        {
            // clientRequest = await _context.clientRequests.FindAsync(id); 

            if (id != clientRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clientRequest.RStatus = Enum.RequestStatus.Waiting;
                    //clientRequest.RequestDate = DateTime.Now;
                    var request = new ClientRequest
                    {
                        RStatus = clientRequest.RStatus,
                        //RequestDate = clientRequest.RequestDate
                    };
                    _context.Update(clientRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientRequestExists(clientRequest.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(My_Request));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        // GET: ClientRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (clientRequest == null)
            {
                return NotFound();
            }

            return View(clientRequest);
        }

        // POST: ClientRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.clientRequests'  is null.");
            }
            var clientRequest = await _context.clientRequests.FindAsync(id);
            if (clientRequest != null)
            {
                _context.clientRequests.Remove(clientRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: All Client Requests For The Employee
        public async Task<IActionResult> My_Request()
        {
            // استعلام لاسترداد الطلبات المرتبطة بالموظف الحالي
            var employeeRequests = await _context.clientRequests
            .Include(c => c.AppUser)
                .Where(c => c.AppUser.Id == _userManager.GetUserId(User))
                .ToListAsync();

            return View(employeeRequests);
        }

        // GET: ClientRequests/ReviewDetails/5
        public async Task<IActionResult> ReviewDetails(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (clientRequest == null)
            {
                return NotFound();
            }

            return View(clientRequest);
        }

        // EDIT: ClientRequests/ReviewDetails/5
        [Route("clientrequests/reviewedit/{id}")]
        public async Task<IActionResult> ReviewEdit(int? id)
        {
            if (id == null || _context.clientRequests == null)
            {
                return NotFound();
            }

            var clientRequest = await _context.clientRequests.FindAsync(id);
            if (clientRequest == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewEdit(int? id, [Bind("RequestId,ClientName,RequestDescription,RequestType,RStatus,RequestDate,ResponseDate,Response,AppUserId,CreatedIn,CreatedBy,ModifiedIn,ModifiedBy")] ClientRequest clientRequest, bool rStatusForm)
        {
            clientRequest = await _context.clientRequests.FindAsync(id);
            if (id != clientRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (rStatusForm == true)
                    {
                        clientRequest.RStatus = Enum.RequestStatus.Accepted;
                        clientRequest.ResponseDate = DateTime.Now;
                        clientRequest.Response = "This Request Has Acceptrd by "+ clientRequest.AppUserId;
                    }
                    else if (rStatusForm == false)
                    {
                        clientRequest.RStatus = Enum.RequestStatus.Rejected;
                        clientRequest.ResponseDate = DateTime.Now;
                        clientRequest.Response = "This Request Has Rejected by " + clientRequest.AppUserId;
                    }
                    else
                    {
                        clientRequest.RStatus = Enum.RequestStatus.Waiting;
                        // clientRequest.RequestDate = DateTime.Now;
                    }

                    var request = new ClientRequest
                    {
                        RStatus = clientRequest.RStatus,
                        RequestDate = clientRequest.RequestDate,
                        ResponseDate = clientRequest.ResponseDate,
                        Response = clientRequest.Response
                    };

                    _context.Update(clientRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientRequestExists(clientRequest.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(My_Request));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Name", clientRequest.AppUserId);
            return View(clientRequest);
        }

        private bool ClientRequestExists(int id)
        {
          return (_context.clientRequests?.Any(e => e.RequestId == id)).GetValueOrDefault();
        }
    }
}

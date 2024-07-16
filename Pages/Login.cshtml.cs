using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public void OnGet(string returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public IActionResult OnPost(string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            // Perform your authentication logic here (e.g., check credentials against database)
            // For simplicity, a basic example:
            if (Input.Username == "admin" && Input.Password == "password")
            {
                // Authentication successful, redirect to returnUrl or another page
                return LocalRedirect(returnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
        }

        // If we reach here, something went wrong, redisplay form
        return Page();
    }

    public class InputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

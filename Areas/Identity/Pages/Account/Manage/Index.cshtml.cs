// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Airbnb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Airbnb.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            public string Description { get; set; }
            public string Work { get; set; }
            public string Language { get; set; }
            public string Location { get; set; }
            public string Photo { get; set; }
            public string FName { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //Username = userName;

            Input = new InputModel
            {
                Description = user.Description,
                Location = user.City,
                Language = user.Language,
                Work = user.Work,
                Photo = user.Photo,
                FName = user.FName,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile img)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var photo = user.Photo;
            if (Input.Photo != photo)
            {
                user.Photo = Input.Photo;
                if (img == null)
                {
                    ModelState.AddModelError("", "Must Upload Image");
                    return Page();
                }
                string filename = user.Id.ToString() + "." + img.FileName.Split(".").Last();
                user.Photo = filename;
                using (var fs = System.IO.File.Create("wwwroot/Images/" + filename))
                {
                    img.CopyTo(fs);
                    await _userManager.UpdateAsync(user);
                }
            }

            var description = user.Description;
            if (Input.Description != description)
            {
                user.Description = Input.Description;
                await _userManager.UpdateAsync(user);
            }
            var location = user.City;
            if (Input.Location != location)
            {
                user.City = Input.Location;
                await _userManager.UpdateAsync(user);
            }
            var language = user.Language;
            if (Input.Language != language)
            {
                user.Language = Input.Language;
                await _userManager.UpdateAsync(user);
            }
            var work = user.Work;
            if (Input.Work != work)
            {
                user.Work = Input.Work;
                await _userManager.UpdateAsync(user);
            }
            //if(Request.Form.Files.Count > 0) {
            //    var file = Request.Form.Files.FirstOrDefault();
            //    using (var dataStream =new MemoryStream())
            //    {
            //        await file.CopyToAsync(dataStream);
            //        user.Photo = dataStream.ToString();
            //    }
            //    await _userManager.UpdateAsync(user);
            //}
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using MyBudget.Components;
using MyBudget.Components.Account;
using MyBudget.Data;

var builder = WebApplication.CreateBuilder(args);

var DefaultConnection = builder.Configuration["MyBudget:DefaultConnection"];
if (string.IsNullOrEmpty(DefaultConnection))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

// Configura��o do DbContext
builder.Services.AddDbContextFactory<MyBudgetContext>(options =>
    options.UseNpgsql(DefaultConnection));

// Configura��o de servi�os
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpContextAccessor();

// Add MudBlazor services
builder.Services.AddMudServices();

// Configura��o do MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.VisibleStateDuration = 1500;
});

// Configura��o do Identity
builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<MyBudgetContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

// Configura��o dos cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/access-denied";
    options.SlidingExpiration = true;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});

// Configura��o de autentica��o e estado
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Configura��o de email
builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

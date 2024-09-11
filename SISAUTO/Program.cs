using DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configurar el Swagger para que permita añadir la capa de seguridad
builder.Services.AddSwaggerGen(options =>
{
    //oauth2 - Se utiliza mediante tokens
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    //
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


//Añadir del contexto de la base de datos a la aplicacion
builder.Services.AddDbContext<SisautoContext>(options =>
{
    //Mandar la cadena de conexion
    options.UseNpgsql(builder.Configuration.GetConnectionString("SISAUTOConnection"));
});

//Tema de autorizacion
//Añadir el paquete de identity(las rutas ya se estan empezando a proteger)
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SisautoContext>();

//Servicios
builder.Services.AddScoped<PaisesService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<ServiciosService>();
builder.Services.AddScoped<OrdenesService>();
builder.Services.AddScoped<DetalleOrdenesService>();
//REpositorios
builder.Services.AddScoped<PaisesRepository>();
builder.Services.AddScoped<ClientesRepository>();
builder.Services.AddScoped<ServiciosRepository>();
builder.Services.AddScoped<OrdenesRepository>();
builder.Services.AddScoped<DetalleOrdenesRepository>();

//crear Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrings",
        policy =>
        {
            //Permite que pueda trabajar desde localhost
            policy.WithOrigins("http://example.com")
                .AllowAnyHeader()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

//Se pueda utilizar el conetxto para ejecutar en formato de migracion
using (var scope = app.Services.CreateScope())
{
    var context =scope.ServiceProvider.GetRequiredService<SisautoContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Manda a una pagina de excepcion (parte de la configuracion de Cors)
    app.UseDeveloperExceptionPage();
}//Manejar el error (parte de la configuracion de Cors)
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

//Llamar aqui para se muestre la autirozacion en el swagger
app.MapIdentityApi<IdentityUser>();

//Llamar al metodo que permita manejar la redirecciones
app.UseHttpsRedirection();

//logina de los Cors
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

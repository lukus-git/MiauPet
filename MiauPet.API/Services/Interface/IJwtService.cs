using MiauPet.API.DTOs;

namespace MiauPet.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}


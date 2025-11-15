using MiauPet.UI.ViewModels;

namespace MiauPet.UI.Services.Interfaces;

public interface IAuthService
{
    Task<(bool Success, string Message)> LoginAsync(LoginVM loginVM);
    Task<(bool Success, string Message)> RegisterAsync(RegistroVM registroDto);
    void Logout();
    bool IsAuthenticated();
    string GetUserToken();
    string GetUserName();
    string GetUserEmail();
    string GetUserFoto();
    string GetUserPerfil();
}
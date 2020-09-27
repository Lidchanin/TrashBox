using System.Threading.Tasks;
using TrashBox.Abstractions;

namespace TrashBox.Services
{
    public interface IPopupService
    {
        Task ShowPopupAsync(BasePopup popup);

        Task HidePopupAsync(BasePopup popup);
    }
}
using Infrastructure.Models;

namespace Silicon_1.Models;

public class AccountDetailsViewModel
{
    public AccountBasicInfoModel AccountBasicInfo { get; set; } = null!;

    public AccountAdressInfo AdressInfo { get; set; } = null!;
}

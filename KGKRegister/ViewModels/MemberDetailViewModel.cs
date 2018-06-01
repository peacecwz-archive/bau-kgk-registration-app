using System;

namespace KGKRegister
{
    public class MemberDetailViewModel : BaseViewModel
    {
        public Member Item { get; set; }
        public MemberDetailViewModel(Member item = null)
        {
            Title = $"{item?.FirstName} {item?.LastName}";
            Item = item;
        }
    }
}

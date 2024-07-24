namespace LibraryManagment.DTOs.LoansDTOs
{
    public class DeleteLoanResponse
    {
        public bool Delete {  get; set; }
        public DeleteLoanResponse(bool delete = true) => Delete = delete;
    }
}

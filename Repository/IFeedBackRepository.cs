namespace MovieAppApi.Repository{
    interface IFeedBackRepository{
        void addFeedBack(string email, string content);
    }
}
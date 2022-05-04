using Npgsql;
namespace MovieAppApi.DataBase{
    class DataBaseInit{
        private DataProvider dataProvider;
        public DataBaseInit(){
            dataProvider = new DataProvider();
        }
        public void Init(){
            if(!DataProvider.CheckConnection()){
                return;
            }
            // create database
            string query = "CREATE DATABASE movieapp";
            dataProvider.ExcuteQueryNoDB(query);

            // create user table
            query = "CREATE TABLE IF NOT EXISTS Users("
                +"id SERIAL PRIMARY KEY,"
                +"AvatarUrl text,"
                +"FirstName VARCHAR(100),"
                +"LastName VARCHAR(100),"
                +"BirthDay date,"
                +"Gender int,"
                +"Email varchar(100),"
                +"Password varchar(100),"
                +"TimeCreated timestamp,"
                +"UNIQUE(Email)"
            +");";           
            dataProvider.ExcuteQuery(query);

            //init user data
            query = "SELECT * FROM Users";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'B',N'Nguyễn','1997/1/15',1,'B@gmail.com', MD5('12345'), now());"
                    +"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'admin',N'admin','1999/5/23',0,'admin', MD5('admin'), now());"
                    +"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'C',N'Trần','1999/5/23',0,'C@gmail.com', MD5('12345'), now());"
                    +"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'G',N'Trần','2001/6/5',0,'G@gmail.com', MD5('12345'), now());"
                    +"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'A',N'Ngọc','1999/2/16',1,'A@gmail.com', MD5('12345'), now());"
                    +"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'Z',N'Huỳnh','2005/11/29',0,'Z@gmail.com', MD5('12345'), now());";
                dataProvider.ExcuteQuery(query);
            }

            // create genre table
            query = "CREATE TABLE IF NOT EXISTS Genre("
            + "id SERIAL PRIMARY KEY,"
            + "GenreName VARCHAR(100)"
            + ")";
            dataProvider.ExcuteQuery(query);

            // init genre data
            query = "SELECT * FROM Genre";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO Genre(GenreName) VALUES (N'Chiến tranh');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Hành Động');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Hoạt Hình');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Tâm lý');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Cổ trang');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Hình sự');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Hài hước');"
                + "INSERT INTO Genre(GenreName) VALUES (N'Gia Đình');";
            }
            dataProvider.ExcuteQuery(query);

            // create director table
            query = "CREATE TABLE IF NOT EXISTS Director("
            + "id SERIAL PRIMARY KEY,"
            + "FullName VARCHAR(100)"
            + ")";
            dataProvider.ExcuteQuery(query);

            // init director data
            query = "SELECT * FROM Director";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO Director(FullName) VALUES ('Jon Watts');" // spider man
                + "INSERT INTO Director(FullName) VALUES ('Kenji Kodama');" // conan
                + "INSERT INTO Director(FullName) VALUES ('Hideo Nishimaki');" // doremon
                + "INSERT INTO Director(FullName) VALUES ('Darren Lynn Bousman');" // saw
                + "INSERT INTO Director(FullName) VALUES ('Kim Byeong-Wook');"; // high kick
            }
            dataProvider.ExcuteQuery(query);

            // create actor table
            query = "CREATE TABLE IF NOT EXISTS Actor("
            + "id SERIAL PRIMARY KEY,"
            + "AvatarUrl text,"
            + "FullName varchar(100)"
            + ")";
            dataProvider.ExcuteQuery(query);
            
            // init actor data
            query = "SELECT * FROM Actor";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO Actor(FullName) VALUES ('Lee Soon-jae');"
                + "INSERT INTO Actor(FullName) VALUES ('Jung Il-woo');"
                + "INSERT INTO Actor(FullName) VALUES ('Seo Min-jung');"
                + "INSERT INTO Actor(FullName) VALUES ('Kim Bum');"
                + "INSERT INTO Actor(FullName) VALUES ('Park Min-young');"
                + "INSERT INTO Actor(FullName) VALUES ('Tobin Bell');"
                + "INSERT INTO Actor(FullName) VALUES ('Cary Elwes');"
                + "INSERT INTO Actor(FullName) VALUES ('Leigh Whannell');"
                + "INSERT INTO Actor(FullName) VALUES ('Tom Holland');"
                + "INSERT INTO Actor(FullName) VALUES ('Willem Dafoe');"
                + "INSERT INTO Actor(FullName) VALUES ('Andrew Garfield');";
            }
            dataProvider.ExcuteQuery(query);

            // create movie table
            query = "CREATE TABLE IF NOT EXISTS Movie("
            + "id SERIAL PRIMARY KEY,"
            + "Director_Id INT,"
            + "Title VARCHAR(255),"
            + "EngTitle VARCHAR(255),"
            + "AvatarUrl text,"
            + "ReleaseYear INT,"
            + "Country VARCHAR(100),"
            + "Rating INT,"
            + "Content text,"
            + "MovieLength INT,"
            + "FOREIGN KEY (Director_Id) REFERENCES Director(id)"
            + ")";
            dataProvider.ExcuteQuery(query);

            // init movie data
            query = "SELECT * FROM Movie";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (1, N'NGƯỜI NHỆN: KHÔNG CÒN NHÀ', 'Spider-Man: No Way Home', '/UserData/MovieAvatar/nguoi-nhen-khong-con-nha-58642-thumbnail-250x350.jpg', 2021, N'Mỹ', 4, N'Spider-Man: No Way Home 2021 CAM Với Danh Tính Của Người Nhện Giờ đã được Tiết Lộ, Peter Nhờ Doctor Strange Giúp đỡ. Khi Một Câu Thần Chú Bị Sai, Những Kẻ Thù Nguy Hiểm Từ Các Thế Giới Khác Bắt đầu Xuất Hiện, Buộc Peter Phải Khám Phá Ra ý Nghĩa Thực Sự Của Việc Trở Thành Người Nhện. Lần đầu tiên trong lịch sử điện ảnh của Người Nhện, thân phận người hàng xóm thân thiện bị lật mở, khiến trách nhiệm làm một Siêu Anh Hùng xung đột với cuộc sống bình thường và đặt người anh quan tâm nhất vào tình thế nguy hiểm. Khi anh nhờ đến giúp đỡ của Doctor Strange để khôi phục lại bí mật, phép thuật đã gây ra lỗ hổng thời không, giải phóng những ác nhân mạnh mẽ nhất từng đối đầu với Người Nhện từ mọi vũ trụ. Bây giờ, Peter sẽ phải vượt qua thử thách lớn nhất của mình, nó sẽ thay đổi không chỉ tương lai của chính anh mà còn là tương lai của cả Đa Vũ Trụ.', 148);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (4, N'LƯỠI CƯA 1', 'Saw 1', '/UserData/MovieAvatar/luoi-cua-1-250x350.jpg.jpg', 2004, N'Mỹ', 5, N'Lưỡi Cưa 1 -  Saw (2004) Phim xoay quanh câu chuyện của hai nạn nhân của kẻ giết người hàng loạt jigsaw: chàng trai trẻ Adam và vị bác sĩ Gordon. Giữa họ là một người đàn ông nằm chết trên vũng máu, tay vẫn cầm khẩu súng. Chẳng ai trong hai người đàn ông biết vì sao nạn nhân kia bị hành quyết. Họ nhận được một lời nhắn ra lệnh Gordon giết Adam trong tám tiếng, nếu không thực hiện thì cả hai sẽ bị giết và cả vợ con của Gordon cũng chết. Cả hai người đàn ông hiểu ra mình đang phải chơi trò chơi sống còn với kẻ giết người điên loạn.', 103);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (4, N'LƯỠI CƯA 2', 'Saw 2', '/UserData/MovieAvatar/luoi-cua-2-250x350.jpg', 2005, N'Mỹ', 3, N'Lưỡi Cưa 2, Saw 2 (2005) Trong khi điều tra một vụ giết người đẫm máu, thanh tra Eric Mason chợt có linh tính đây chính là \"tác phẩm\" của tên giết người hàng loạt có biệt danh Jigsaw - kẻ đã từng biến mất sau khi thực hiện một loạt các vụ giết người đầy dã man. Đúng như linh tính mách bảo, Jigsaw đã trở lại và hắn đã bắt đến 8 người và buộc các nạn nhân phải bước vào “cuộc chơi” dã man mà hắn đã vạch sẵn cho họ.', 93);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (4, N'LƯỠI CƯA 3', 'Saw 3', '/UserData/MovieAvatar/luoi-cua-3-250x350.jpg', 2006, N'Mỹ', 2, N'Lưỡi Cưa 3 - Saw 3 (2006) Jigsaw lại biến mất cùng với nhân viên tập sự mới của hắn là Amanda. Một lần nữa, kẻ giết người hàng loạt này lại thoát khỏi sự truy đuổi của cảnh sát. Trong khi cả thành phố đang hoảng hốt, các thám tử cố gắng tìm ra được chỗ ẩn nấp của Jigsaw thì bác sĩ Lynn Denlon lại trở thành con chốt mới nhất trên “bàn cờ” khủng khiếp của hắn. Trên đường trở về nhà sau ca trực, bác sỹ Lynn bị bắt cóc và đưa tới một nhà kho bỏ hoang. Tại đây, cô gặp Jigsaw đang nằm liệt giường và cận kề cái chết. Lynn bị bắt buộc phải làm mọi cách để giữ lại mạng sống của Jigsaw cho đến khi nào Jeff - một nạn nhân xấu số khác - hoàn thành “trò chơi” của tên sát nhân này. Chạy đua với sự sống còn, Lynn và Jeff tìm mọi cách chống lại trò chơi đồi bại nhưng cả 2 đã không lường trước được rằng Jigsaw đã có kế hoạch khủng khiếp dành cho họ. Bộ phim Lưỡi Cưa 3 tiếp nối phần 2 hứa hẹn nhiều bất ngờ..', 108);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (2, N'Thám Tử Lừng Danh Conan', 'Detective Conan', '/UserData/MovieAvatar/tham-tu-lung-danh-conan-28650-thumbnail-250x350.jpg', 1996, N'Nhật Bản', 5, N'Mở đầu câu truyện, cậu học sinh trung học 17 tuổi (trong truyện tranh là 16) Shinichi Kudo (Jimmy Kudo) bị biến thành cậu bé Conan Edogawa. Shinichi trong phần đầu của Thám tử lừng danh Conan được miêu tả là một thám tử học đường. Trong một lần đi chơi công viên \"Miền Nhiệt đới\" với cô bạn từ thuở nhỏ (cũng là bạn gái) Ran Mori (Rachel Moore), cậu bị dính vào vụ án một hành khách trên Chuyến tàu tốc hành trong công viên, Kishida (Kenneth), bị giết trong một vụ án cắt đầu rùng rợn. Cậu đã làm sáng tỏ vụ án và trên đường về nhà, chứng kiến một vụ làm ăn mờ ám của những người đàn ông mặc toàn đồ đen. Kudo bị phát hiện, bị đánh ngất sau đó những người đàn ông áo đen đã cho cậu uống một thứ thuốc độc chưa qua thử nghiệm là Apotoxin-4869 (APTX4869) với mục đích thủ tiêu cậu. Tuy nhiên chất độc đã không giết chết Kudo. Khi tỉnh lại, cậu bàng hoàng nhận thấy thân thể mình đã bị teo nhỏ trong hình dạng của một cậu học sinh tiểu học.', 23);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (5, N'Gia Đình Là Số 1 Phần 1', 'The Unstoppable High Kick', '/UserData/MovieAvatar/spl-tvhayorg-11001.jpg', 2007, N'Hàn Quốc', 4, N'Phim Gia Đình Là Số 1 Phần 1 (167/167 Tập Cuối) trọn bộ lồng tiếng Ra đời từ năm 2006, bộ phim High Kick (phát sóng phần 1 tại Việt Nam với tên gọi Gia đình là số 1) tạo nên cơn sốt tại Hàn Quốc vì những câu chuyện quen thuộc, gần gũi với mọi gia đình. Bộ phim đã tạo thành bệ phóng cho rất nhiều diễn viên còn vô danh trước đó. Nội dung phim xoay quanh những câu chuyện trong cuộc sống của các thành viên của nhà họ Lee, một gia đình Hàn Quốc sống ở Seoul với nhiều vui buồn lẫn lộn. Phim về gia đình là số 1 sẽ được phát sóng bắt đầu từ mùa đông 2006 đến mùa hè 2007, dài 167 tập, mỗi tập gồm 2 đến 3 tình huống khác nhau được bố cục xen kẽ. Gia đình là số 1 là một trong những sitcom gia đình đình đám của điện ảnh xứ Hàn. Từ khi ra mắt phần 1 vào năm 2007, sitcom này đã nhanh chóng tạo nên một cơn sốt thu hút lượng người xem khổng lồ và góp phần đưa thể loại sitcom trở lại thời hoàng kim sau khi bị “thất sủng” một thời gian dài. Dù đã cho ra mắt phần 1 và 2 với độ dài mỗi phần lên tới hơn 100 tập nhưng sức hút của bộ phim vẫn chưa hề có dấu hiệu giảm nhiệt.', 29);"
                + "INSERT INTO Movie(Director_Id, Title, EngTitle, AvatarUrl, ReleaseYear, Country, Rating, Content, MovieLength)"
                + "VALUES (2, N'7 VIÊN NGỌC RỒNG SIÊU CẤP: HÀNH TINH NGỤC TÙ (PHẦN 2)', 'Super Dragon Balls Heroes: Big Bang Mission 2 (2021)', '/UserData/MovieAvatar/7-vien-ngoc-rong-sieu-cap-hanh-tinh-nguc-tu-phan-2-60832-thumbnail.jpg', 2021, N'Nhật Bản', 8.4, N'Super Dragon Ball Heroes (Phần 2) - Hành Tinh Ngục Tù này vẫn sẽ xoay quanh cuộc chiến với gã ác nhân Fu. Tuy nhiên nó sẽ mang đến một nhân vật mới vô cùng thú vị, người mà khiến các vị Thần cũng phải e dè.', 10);";
                dataProvider.ExcuteQuery(query);
            }

            // create moviegenre table
            query = "CREATE TABLE IF NOT EXISTS MovieGenre("
            + "Movie_Id INT,"
            + "Genre_Id INT,"
            + "FOREIGN KEY (Movie_Id) REFERENCES Movie(id),"
            + "FOREIGN KEY (Genre_Id) REFERENCES Genre(id)"
            + ")";
            dataProvider.ExcuteQuery(query);

            // init moviegenre data
            query = "SELECT * FROM MovieGenre";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (1, 1);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (1, 2);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (1, 7);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (2, 2);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (2, 4);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (2, 6);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (3, 2);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (3, 4);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (3, 6);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (4, 2);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (4, 4);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (4, 6);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (5, 2);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (5, 3);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (5, 6);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (5, 7);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (5, 8);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (6, 7);"
                + "INSERT INTO MovieGenre(Movie_Id, Genre_Id) VALUES (6, 8);";
                dataProvider.ExcuteQuery(query);
            }

            // create movieactor table
            query = "CREATE TABLE IF NOT EXISTS MovieActor("
            + "Movie_Id INT,"
            + "Actor_Id INT,"
            + "FOREIGN KEY (Movie_Id) REFERENCES Movie(id),"
            + "FOREIGN KEY (Actor_Id) REFERENCES Actor(id)"
            + ")";
            dataProvider.ExcuteQuery(query);

            // init movieactor data
            query = "SELECT * FROM MovieActor";
            if(dataProvider.GetDataTable(query).Rows.Count == 0){
                query = "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (1, 11);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (1, 9);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (1, 10);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (2, 6);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (2, 7);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (2, 8);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (3, 6);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (3, 7);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (3, 8);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (4, 6);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (4, 7);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (4, 8);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (6, 1);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (6, 2);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (6, 3);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (6, 4);"
                + "INSERT INTO MovieActor(Movie_Id, Actor_Id) VALUES (6, 5);";
                dataProvider.ExcuteQuery(query);
            }
        }
        public void Drop(){
            string query = "DROP DATABASE IF EXISTS movieapp";
            dataProvider.ExcuteQueryNoDB(query);
        }
    }
}
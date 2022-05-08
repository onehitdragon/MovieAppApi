namespace MovieAppApi.Model{
    class Episode{
        private int number;
        private string sourceUrl;
        public int Number{
            get{
                return number;
            }
            set{
                number = value;
            }
        }
        public string SourceUrl{
            get{
                return sourceUrl;
            }
            set{
                sourceUrl = value;
            }
        }
        public Episode(int number, string sourceUrl){
            this.number = number;
            this.sourceUrl = sourceUrl;
        }
    }
}
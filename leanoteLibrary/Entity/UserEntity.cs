namespace leanoteLibrary.Entity
{
    public class UserEntity
    {
         public string Userid { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 备注 用户自签名
        /// </summary>
        public string Intro { get; set; }
        public  string Address { get; set; }
        /// <summary>
        /// 用户token授权
        /// </summary>
        public string Token{get; set; }
        public string Telephone { get;set; }
        public string QQ { get;set; }
        public string Twitter { get;set; }
        public string Avatar { get;set; }
        public int Rank { get;set; }
        public int Credit { get;set; }
        public int Gb { get; set; }

    }
}

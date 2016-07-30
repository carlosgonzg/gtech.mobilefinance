using gtech.mobilefinance.dal;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace gtech.mobilefinance.bll
{
    public class AuthHandler : IDisposable
    {
        private string _saltSecret;
        private DataContext _authContext;
        private DbSet<User> _userManager;

        public AuthHandler()
        {
            _saltSecret = "ElMundoDeberiaGirarPorSiempre";
            _authContext = new DataContext();
            _userManager = _authContext.Set<User>();
        }
        public string getEncryptedPassword(string password)
        {
            string pass = "";
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            pass = BCrypt.Net.BCrypt.HashPassword(password + _saltSecret, salt);
            return pass;
        }
        private bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(userEnteredPassword + _saltSecret, hashedPwdFromDatabase);
        }
        //RegisterUser
        public async Task<User> Create(dal.User userModel)
        {
                userModel.Validate();
                var isThereUser = await GetUser(userModel.Username);
                if (isThereUser != null)
                {
                    throw new Exception("The User already exists.");
                }
                userModel.Password = getEncryptedPassword(userModel.Password);
                _userManager.Add(userModel);
                var userId = await _authContext.SaveChangesAsync();
                userModel.Id = userId;
                return userModel;
        }

        //Find User
        public async Task<User> Login(string username, string password)
        {
            var user = await (from b in _userManager where b.Username == username select b).FirstAsync();
            var matched = DoesPasswordMatch(user.Password, password);
            return matched ? user : null;
        }
        public async Task<User> GetActualUser()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            return await (from b in _userManager where b.Username == username select b).FirstAsync();
        }
        public async Task<User> GetUser(string username)
        {
            return await (from b in _userManager where b.Username == username select b).FirstOrDefaultAsync();
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}

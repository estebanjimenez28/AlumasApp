using AlumasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlumasApp.Models;

namespace AlumasApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //el VM funciona como puente entre el modelo y la vista 
        //en sentido teórico el vm "siente" los cambios de la vista 
        //y los pasa al modelo de forma automática, o viceversa
        //según se use en uno o dos sentidos. 

        //también se puede usar (como en este caso particular, 
        //simplemente como mediador de procesos. Más adelante se usará 
        //commands y bindings en dos sentidos 

        //primero en formato de funciones clásicas
        public User MyUser { get; set; }

        public UserRole MyUserRole { get; set; }

        public Client MyClient { get; set; }

        public Branch MyBranch { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public ClientDTO MyClientDTO { get; set; }  

        public Employee MyEmployee { get; set; }

        public EmployeeDTO MyEmployeeDTO { get; set; }  

        public DeliveryDTO MyDeliveryDTO { get; set; } 

        public Delivery MyDelivery { get; set; }

        public Product MyProduct { get; set; }

        public ProductDTO MyProductDTO { get; set; }

        public ProductCategory MyProductCategory { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyClient = new Client();
            MyUserRole = new UserRole();
            MyBranch = new Branch();
            MyUserDTO = new UserDTO();
            MyClientDTO = new ClientDTO();
            MyEmployee = new Employee();  
            MyEmployeeDTO = new EmployeeDTO();
            MyDelivery = new Delivery();
            MyDeliveryDTO = new DeliveryDTO();
            MyProduct = new Product();
            MyProductDTO = new ProductDTO();
            MyProductCategory = new ProductCategory();
        }

        //funciones 

        //funcion que carga los datos del objeto de usuario global 
        public async Task<UserDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUserInfo(pEmail);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }
        //funcion que carga los datos del objeto de cliente global 
        public async Task<ClientDTO> GetClientDataAsync(string PEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ClientDTO clientDTO = new ClientDTO();

                clientDTO = await MyClientDTO.GetClientInfo(PEmail);

                if (clientDTO == null) return null;

                return clientDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }
        //funcion que carga los datos del objeto de empleado global 
        public async Task<EmployeeDTO> GetEmployeeDataAsync(string PemployeeName)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();

                employeeDTO = await MyEmployeeDTO.GetEmployeeInfo(PemployeeName);

                if (employeeDTO == null) return null;

                return employeeDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }

        //funcion que carga los datos del objeto de entrega global 
        public async Task<DeliveryDTO> GetDeliveryDataAsync(string Pdescripcion)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                DeliveryDTO deliveryDTO = new DeliveryDTO();

                deliveryDTO = await MyDeliveryDTO.GetDeliveryInfo(Pdescripcion);

                if (deliveryDTO == null) return null;

                return deliveryDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }
        //funcion que carga los datos del objeto de producto global 
        public async Task<ProductDTO> GetProductDataAsync(string PproductName)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ProductDTO productDTO = new ProductDTO();

                productDTO = await MyProductDTO.GetProductInfo(PproductName);

                if (productDTO == null) return null;

                return productDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }


        public async Task<bool> UpdateUser(UserDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUserDTO = pUser;

                bool R = await MyUserDTO.UpdateUserAsync();



                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }


        }

        public async Task<bool> UpdatePassword(UserDTO pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUserDTO = pPassword;

                bool R = await MyUserDTO.UpdatePasswordAsync();



                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }


        }



        //función para validar el ingreso del usuario al app por medio del 
        //login 

        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            //debemos poder controlar que no se ejecute la operación más de una vez 
            //en este caso hay una funcionalidad pensada para eso en BaseViewModel que 
            //fue heredada al definir esta clase. 
            //Se usará una propiedad llamada "IsBusy" para indicar que está en proceso de ejecución
            //mientras su valor sea verdadero 

            //control de bloqueo de funcionalidad 
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        //carga la lista de roles, que se usaran por ejemplo en el picker de roles en la
        //creación de un usuario nuevo
        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();

                roles = await MyUserRole.GetAllUserRolesAsync();

                if (roles == null)
                {
                    return null;
                }

                return roles;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //carga la lista de sucursales, que se usaran por ejemplo en el picker de roles en la
        //creación de un usuario nuevo
        public async Task<List<Branch>> GetBranchAsync()
        {
            
            try
            {
                List<Branch> branches = new List<Branch>();

                branches = await MyBranch.GetAllBranchAsync();

                if (branches == null)
                {
                    return null;
                }

                return branches;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //carga la lista de clientes, que se usaran por ejemplo en el picker de roles en la
        //creación de un usuario nuevo
        public async Task<List<Client>> GetClientAsync()
        {
            try
            {
                List<Client> clients = new List<Client>();

                clients = await MyClient.GetAllClientAsync();

                if (clients == null)
                {
                    return null;
                }

                return clients;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            try
            {
                List<ProductCategory> categories = new List<ProductCategory>();

                categories = await MyProductCategory.GetAllProductCategoryAsync();

                if (categories == null)
                {
                    return null;
                }

                return categories;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //función de creación de usuario nuevo 
        public async Task<bool> AddUserAsync(string pEmail,
                                             string pPassword,
                                             string pName,
                                             string pBackUpEmail,
                                             string pPhoneNumber,
                                             string pAddress,
                                             int pUserRoleID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();

                MyUser.Email = pEmail;
                MyUser.Password = pPassword;
                MyUser.Name = pName;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Address = pAddress;
                MyUser.UserRoleId = pUserRoleID;

                bool R = await MyUser.AddUserAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }
        //función de creación de cliente nuevo 
        public async Task<bool> AddClientAsync(string pClientName,
                                             string pAddress,
                                             string pPhoneNumber,
                                             string pBackUpEmail,
                                             int pBranchID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();

            
                MyClient.ClientName = pClientName;
                MyClient.BackUpEmail = pBackUpEmail;
                MyClient.PhoneNumber = pPhoneNumber;
                MyClient.Address = pAddress;
                MyClient.BranchBranchId = pBranchID;

                bool R = await MyClient.AddClientAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }
        //función de creación de empleado nuevo 
        public async Task<bool> AddEmployeeAsync(string pEmployeeName,
                                             string pAddress,
                                             string pPhoneNumber,
                                             string pBackUpEmail,
                                             int pBranchID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();


                MyEmployee.EmployeeName = pEmployeeName;
                MyEmployee.BackUpEmail = pBackUpEmail;
                MyEmployee.EmployeePhoneNumber = pPhoneNumber;
                MyEmployee.EmployeeAddress = pAddress;
                MyEmployee.BranchBranchId = pBranchID;

                bool R = await MyEmployee.AddEmployeeAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

        //función de creación de ruta nueva
        public async Task<bool> AddDeliveryAsync(
                                             string paddress,
                                             string pDescription,
                                             int pClientID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();


                MyDelivery.Address = paddress;
                MyDelivery.Description = pDescription;
                MyDelivery.ClientsClientId = pClientID;

                bool R = await MyDelivery.AddDeliveryAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

        //función de creación de producto nuevo
        public async Task<bool> AddProductAsync(
                                             string pproductName,
                                             decimal pquantity,
                                             int pprice,
                                             int pbranchid,
                                             int pclientid,
                                             int pproductCategoryid)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();


                MyProduct.ProductName = pproductName;
                MyProduct.Quantity = pquantity;
                MyProduct.Price = pprice;   
                MyProduct.BranchBranchId = pbranchid;   
                MyProduct.ClientsClientId = pclientid;  
                MyProduct.ProductCategoryProductCategoryId = pproductCategoryid;    

                bool R = await MyProduct.AddProductAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

        internal Task<bool> AddProductAsync(string v1, string v2, string v3, string v4, int productCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
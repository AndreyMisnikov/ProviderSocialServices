using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProviderSocialServices.ObjectBD;
using System.Configuration;


namespace BD
{
    public class WorkWithBD
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        private static SqlConnection connection;

        static WorkWithBD()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {   
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #region GetAll
        public List<Activity> GetActivities()
        {
            SqlCommand command = new SqlCommand("Select * From Activity", connection );

            SqlDataReader reader = command.ExecuteReader();
            List<Activity> listActivities = new List<Activity>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Activity"];
                string name = (string)reader["Name"];

                listActivities.Add(new Activity { Id_Activity = id, Name = name });
            }
            reader.Close();
            return listActivities;
        }
        public List<AvailableService> GetAvailableServices()
        {
            SqlCommand command = new SqlCommand("Select * From AvailableService", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<AvailableService> listAvailableServices = new List<AvailableService>();
            while (reader.Read())
            {
                int id = (int)reader["Id_AvailableService"];
                string name = (string)reader["Name"];

                listAvailableServices.Add(new AvailableService { Id_AvailableService = id, Name = name });
            }
            reader.Close();
            return listAvailableServices;
        }
        public List<CategoryOfClient> GetCategoryOfClients()
        {
            SqlCommand command = new SqlCommand("Select * From CategoryOfСlient", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<CategoryOfClient> listCategoryOfClients = new List<CategoryOfClient>();
            while (reader.Read())
            {
                int id = (int)reader["Id_CategoryOfClient"];
                string name = (string)reader["Name"];

                listCategoryOfClients.Add(new CategoryOfClient { Id_CategoryOfClient = id, Name = name });
            }
            reader.Close();
            return listCategoryOfClients;
        }
        public List<Contact> GetContacts()
        {
            SqlCommand command = new SqlCommand("Select * From Contact", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Contact> listContact = new List<Contact>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Contact"];
                string typeContact = (string)reader["TypeContact"];
                string valueContact = (string)reader["ValueContact"];
                int idOrg = -1;
                idOrg = (int)reader["Id_Organization"];

                listContact.Add(new Contact { Id_Contact = id, TypeContact = typeContact, ValueContact = valueContact, Id_Organization = idOrg });
            }
            reader.Close();
            return listContact;
        }
        public List<GeographyOfActivity> GetGeographyOfActivities()
        {
            SqlCommand command = new SqlCommand("Select * From GeographyOfActivity", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<GeographyOfActivity> listGeographyOfActivity = new List<GeographyOfActivity>();
            while (reader.Read())
            {
                int id = (int)reader["Id_GeographyOfActivity"];
                string name = (string)reader["Name"];

                listGeographyOfActivity.Add(new GeographyOfActivity { Id_GeographyOfActivity = id, Name = name });
            }
            reader.Close();
            return listGeographyOfActivity;

        }
        public List<SourceFinance> GetSourceFinance()
        {
            SqlCommand command = new SqlCommand("Select * From SourceFinance", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<SourceFinance> listSourceFinance = new List<SourceFinance>();
            while (reader.Read())
            {
                int id = (int)reader["Id_SourceFinance"];
                string name = (string)reader["Name"];

                listSourceFinance.Add(new SourceFinance { Id_SourceFinance = id, Name = name });
            }
            reader.Close();
            return listSourceFinance;
        }

        /// <summary>
        /// Если у организации пустое поле, возвращает его как null.
        /// Datetime, если пустой - DateTime.Now 
        /// </summary>
        public List<Organization> GetOrganizations()
        {
            SqlCommand command = new SqlCommand("Select * From Organization", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization> listOrganizations = new List<Organization>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Organization"];
                string name = (string)reader["Name"];

                string fullName;
                if ((reader["FullName"] != DBNull.Value) && (reader["FullName"] != null))
                {
                    fullName = (string)reader["FullName"];
                }
                else
                {
                    fullName = null;
                }

                DateTime dateReg;
                if ((reader["DateReg"] != DBNull.Value) && (reader["DateReg"] != null))
                {
                    dateReg = (DateTime)reader["DateReg"];
                }
                else
                {
                    dateReg = DateTime.Now;
                }

                string mission;
                if ((DBNull.Value != reader["Mission"]) && (reader["Mission"] != null))
                {
                    mission = (string)reader["Mission"];
                }
                else
                {
                    mission = null;
                }


                string matTechBase;
                if ((DBNull.Value != reader["MaterialTechnicalBase"]) && (reader["MaterialTechnicalBase"] != null))
                {
                    matTechBase = (string)reader["MaterialTechnicalBase"];
                }
                else
                {
                    matTechBase = null;
                }

                string settlementAccount;
                if ((DBNull.Value != reader["SettlementAccount"]) && (reader["SettlementAccount"] != null))
                {
                    settlementAccount = (string)reader["SettlementAccount"];
                }
                else
                {
                    settlementAccount = null;
                }

                int idOrgLegForm = -1;
                if ((DBNull.Value != reader["Id_OrganizationLegalForm"]) && (reader["Id_OrganizationLegalForm"] != null))
                {
                    idOrgLegForm = (int)reader["Id_OrganizationLegalForm"];
                }

                listOrganizations.Add(new Organization { Id_Organization = id, Name = name, FullName = fullName, DateReg = dateReg, Mission = mission, MaterialTechnicalBase = matTechBase, SettlementAccount = settlementAccount, Id_OrganizationLegalForm = idOrgLegForm });
            }
            reader.Close();
            return listOrganizations;
        }
        public List<Organization_Activity> GetReferenceOrg_Activity()
        {
            SqlCommand command = new SqlCommand("Select * From Organization_Activity", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization_Activity> listRef = new List<Organization_Activity>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int idOrg = (int)reader["Id_Organization"];
                int idAct = (int)reader["Id_Activity"];

                listRef.Add(new Organization_Activity { Id = id, Id_Activity = idAct, Id_Organization = idOrg });
            }
            reader.Close();
            return listRef;
        }
        public List<Organization_AvailableService> GetReferenceOrg_AvailableService()
        {
            SqlCommand command = new SqlCommand("Select * From Organization_AvailableService", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization_AvailableService> listRef = new List<Organization_AvailableService>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int idOrg = (int)reader["Id_Organization"];
                int idAvS = (int)reader["Id_AvailableService"];

                listRef.Add(new Organization_AvailableService { Id = id, Id_AvailableService = idAvS, Id_Organization = idOrg });
            }
            reader.Close();
            return listRef;
        }
        public List<Organization_CategoryOfClient> GetReferenceOrg_CategoryOfClient()
        {
            SqlCommand command = new SqlCommand("Select * From Organization_CategoryOfClient", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization_CategoryOfClient> listRef = new List<Organization_CategoryOfClient>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int idOrg = (int)reader["Id_Organization"];
                int idCategoryClient = (int)reader["Id_CategoryOfClient"];

                listRef.Add(new Organization_CategoryOfClient { Id = id, Id_CategoryOfClient = idCategoryClient, Id_Organization = idOrg });
            }
            reader.Close();
            return listRef;
        }
        public List<Organization_GeographyOfActivity> GetReferenceOrg_GeographyOfActivity()
        {
            SqlCommand command = new SqlCommand("Select * From Organization_GeographyOfActivity", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization_GeographyOfActivity> listRef = new List<Organization_GeographyOfActivity>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int idOrg = (int)reader["Id_Organization"];
                int idGeographyOfActivity = (int)reader["Id_GeographyOfActivity"];

                listRef.Add(new Organization_GeographyOfActivity { Id = id, Id_GeographyOfActivity = idGeographyOfActivity, Id_Organization = idOrg });
            }
            reader.Close();
            return listRef;
        }
        public List<Organization_SourceFinance> GetReferenceOrg_SourceFinance()
        {
            SqlCommand command = new SqlCommand("Select * From Organization_SourceFinance", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Organization_SourceFinance> listRef = new List<Organization_SourceFinance>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int idOrg = (int)reader["Id_Organization"];
                int idSourceFinance = (int)reader["Id_SourceFinance"];

                string settlementAccount;
                if (DBNull.Value != reader["SettlementAccount"])
                {
                    settlementAccount = (string)reader["SettlementAccount"];
                }
                else
                {
                    settlementAccount = null;
                }

                listRef.Add(new Organization_SourceFinance { Id = id, Id_Organization = idOrg, Id_SourceFinance = idSourceFinance, SettlementAccount = settlementAccount });
            }
            reader.Close();
            return listRef;
        }
        public List<OrganizationLegalForm> GetOrganizationLegalForms()
        {
            SqlCommand command = new SqlCommand("Select * From OrganizationLegalForm", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<OrganizationLegalForm> listOrgLegFroms = new List<OrganizationLegalForm>();
            while (reader.Read())
            {
                int id = (int)reader["Id_OrganizationLegalForm"];
                string name = (string)reader["Name"];

                listOrgLegFroms.Add(new OrganizationLegalForm { Id_OrganizationLegalForm = id, Name = name });
            }
            reader.Close();
            return listOrgLegFroms;
        }

        /// <summary>
        /// Может вернуть null у поля Information
        /// </summary>
        public List<GroupPeoples> GetGroupsPeoples()
        {
            SqlCommand command = new SqlCommand("Select * From GroupPeoples", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<GroupPeoples> listGroupsPeoples = new List<GroupPeoples>();
            while (reader.Read())
            {
                int id = (int)reader["Id_GroupPeoples"];
                string name = (string)reader["Name"];

                string information;
                if ((DBNull.Value != reader["Information"]) && (reader["Information"] != null))
                {
                    information = (string)reader["Information"];
                }
                else
                {
                    information = null;
                }

                int idOrg = (int)reader["Id_Organization"];

                listGroupsPeoples.Add(new GroupPeoples { Id_GroupPeoples = id, Name = name, Information = information, Id_Organization = idOrg });
            }
            reader.Close();
            return listGroupsPeoples;
        }
        public List<PhotoMaterialTechnicalBase> GetPhotosMaterialTechnicalBases()
        {
            SqlCommand command = new SqlCommand("Select * From PhotoMaterialTechnicalBase", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<PhotoMaterialTechnicalBase> listPhotoMaterialTechnicalBase = new List<PhotoMaterialTechnicalBase>();
            while (reader.Read())
            {
                int id = (int)reader["Id_PhotoMaterialTechnicalBase"];
                string photo = (string)reader["Photo"];
                int idOrg = (int)reader["Id_Organization"];

                listPhotoMaterialTechnicalBase.Add(new PhotoMaterialTechnicalBase { Id_PhotoMaterialTechnicalBase = id, Photo = photo, Id_Organization = idOrg });
            }
            reader.Close();
            return listPhotoMaterialTechnicalBase;
        }

        /// <summary>
        /// Information и Photo мб Null
        /// </summary>
        /// <returns></returns>
        public List<HeadOrganization> GetHeadsOrganizations()
        {
            SqlCommand command = new SqlCommand("Select * From HeadOrganization", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<HeadOrganization> listHeadsOrganizations = new List<HeadOrganization>();
            while (reader.Read())
            {
                int id = (int)reader["Id_HeadOrganization"];
                string name = (string)reader["Name"];

                string information;
                if ((DBNull.Value != reader["Information"]) && (reader["Information"] != null))
                {
                    information = (string)reader["Information"];
                }
                else
                {
                    information = null;
                }

                string photo;
                if ((DBNull.Value != reader["Photo"]) && (reader["Photo"] != null))
                {
                    photo = (string)reader["Photo"];
                }
                else
                {
                    photo = null;
                }

                int idOrg = (int)reader["Id_Organization"];

                listHeadsOrganizations.Add(new HeadOrganization { Id_HeadOrganization = id, Name = name, Information = information, Photo = photo, Id_Organization = idOrg });
            }
            reader.Close();
            return listHeadsOrganizations;
        }
        public List<Project> GetProjects()
        {
            SqlCommand command = new SqlCommand("Select * From Project", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Project> listProject = new List<Project>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Project"];
                string name = (string)reader["Name"];
                int idOrg = (int)reader["Id_Organization"];

                listProject.Add(new Project { Id_Project = id, Name = name, Id_Organization = idOrg });
            }
            reader.Close();
            return listProject;
        }

        /// <summary>
        /// Description и Conditions мб null
        /// </summary>
        /// <returns></returns>
        public List<Service> GetService()
        {
            SqlCommand command = new SqlCommand("Select * From Service", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Service> listServices = new List<Service>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Service"];
                string name = (string)reader["Name"];

                string description;
                if ((DBNull.Value != reader["Description"]) && (reader["Description"] != null))
                {
                    description = (string)reader["Description"];
                }
                else
                {
                    description = null;
                }

                string conditions;
                if ((DBNull.Value != reader["Conditions"]) && (reader["Conditions"] != null))
                {
                    conditions = (string)reader["Conditions"];
                }
                else
                {
                    conditions = null;
                }

                int idOrg = (int)reader["Id_Organization"];

                listServices.Add(new Service { Id_Service = id, Description = description, Conditions = conditions, Name = name, Id_Organization = idOrg });
            }
            reader.Close();
            return listServices;
        }
        #endregion

        #region GetNames
        public List<string> GetNamesOrganizationLegalForms()
        {
            SqlCommand command = new SqlCommand("Select * From NamesOrganizationLegalForms", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listOrgLegFroms = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listOrgLegFroms.Add(name);
            }
            reader.Close();
            return listOrgLegFroms;
        }
        public List<string> GetNamesActivities()
        {
            SqlCommand command = new SqlCommand("Select * From NamesActivities", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listActivity = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listActivity.Add(name);
            }
            reader.Close();
            return listActivity;
        }
        public List<string> GetNamesAvailableServices()
        {
            SqlCommand command = new SqlCommand("Select * From NamesAvailableServices", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listAvailableServices = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listAvailableServices.Add(name);
            }
            reader.Close();
            return listAvailableServices;
        }
        public List<string> GetNamesCategoriesOfClient()
        {
            SqlCommand command = new SqlCommand("Select * From NamesCategoriesOfClient", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listCategoryOfClients = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listCategoryOfClients.Add(name);
            }
            reader.Close();
            return listCategoryOfClients;
        }
        public List<string> GetNamesGeographiesOfActivity()
        {
            SqlCommand command = new SqlCommand("Select * From NamesGeographiesOfClient", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listGeographyOfActivities = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listGeographyOfActivities.Add(name);
            }
            reader.Close();
            return listGeographyOfActivities;
        }
        public List<string> GetNamesSourcesFinance()
        {
            SqlCommand command = new SqlCommand("Select * From NamesSourcesFinance", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listSourcesFinance = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listSourcesFinance.Add(name);
            }
            reader.Close();
            return listSourcesFinance;
        }
        public List<string> GetNamesOrganizations()
        {
            SqlCommand command = new SqlCommand("Select * From NamesOrganizations", connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> listNamesOrganizations = new List<string>();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                listNamesOrganizations.Add(name);
            }
            reader.Close();
            return listNamesOrganizations;
        }
        #endregion
        public string GetNameOrganizationByID(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select Name From Organization Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            return (string)command.ExecuteScalar();
        }


        #region GetNameManyToManyToOrganization
        public List<string> GetActivitiesNamesToOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetActivitiesNamesToOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            List<string> listActivitiesNames = new List<string>();


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameActivity = (string)reader["Name"];
                listActivitiesNames.Add(nameActivity);
            }
            reader.Close();
            return listActivitiesNames;
        }
        public List<string> GetAvailableServicesNamesToOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetAvailableServicesNamesToOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            List<string> listAvailableServicesNames = new List<string>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameAvailableService = (string)reader["Name"];
                listAvailableServicesNames.Add(nameAvailableService);
            }
            reader.Close();
            return listAvailableServicesNames;
        }
        public List<string> GetCategoriesOfClientNamesToOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetCategoriesOfClientNamesToOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            List<string> listCategoriesOfClientNames = new List<string>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameCategoryOfClient = (string)reader["Name"];
                listCategoriesOfClientNames.Add(nameCategoryOfClient);
            }
            reader.Close();
            return listCategoriesOfClientNames;
        }
        public List<string> GetGeographyOfActivitiesNamesToOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetGeographyOfActivitiesNamesToOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            List<string> listGeographyOfActivitiesNames = new List<string>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameGeographyOfActivity = (string)reader["Name"];
                listGeographyOfActivitiesNames.Add(nameGeographyOfActivity);
            }
            reader.Close();
            return listGeographyOfActivitiesNames;
        }
        public List<string> GetSourcesFinanceNamesToOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetSourcesFinanceNamesToOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            List<string> listSourcesFinanceNames = new List<string>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameSourceFinance = (string)reader["Name"];
                listSourcesFinanceNames.Add(nameSourceFinance);
            }
            reader.Close();
            return listSourcesFinanceNames;
        }

        #endregion

        public string GetOrganizationLegalFormOrganizationById(int idOrg)
        {
            SqlCommand command = new SqlCommand("GetOrganizationLegalFormOrganizationById", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            return (string)command.ExecuteScalar();
        }


        #region GetIdByName
        public int GetIdActivityByName(string nameActivity)
        {
            SqlCommand command = new SqlCommand("Select Id_Activity From Activity Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameActivity);

            return (int)command.ExecuteScalar();
        }
        public int GetIdAvailableServiceByName(string nameAvailableService)
        {
            SqlCommand command = new SqlCommand("Select Id_AvailableService From AvailableService Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameAvailableService);

            return (int)command.ExecuteScalar();
        }
        public int GetIdCategoryOfClientByName(string nameCategoryOfClient)
        {
            SqlCommand command = new SqlCommand("Select Id_CategoryOfClient From CategoryOfClient Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameCategoryOfClient);

            return (int)command.ExecuteScalar();
        }
        public int GetIdGeographyOfActivityByName(string nameGeographyOfActivity)
        {
            SqlCommand command = new SqlCommand("Select Id_GeographyOfActivity From GeographyOfActivity Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameGeographyOfActivity);

            return (int)command.ExecuteScalar();
        }
        public int GetIdOrganizationLegalFormByName(string nameOrganizationLegalForm)
        {
            SqlCommand command = new SqlCommand("Select Id_OrganizationLegalForm From OrganizationLegalForm Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameOrganizationLegalForm);

            return (int)command.ExecuteScalar();
        }
        public int GetIdSourceFinanceByName(string nameSourceFinance)
        {
            SqlCommand command = new SqlCommand("Select Id_SourceFinance From SourceFinance Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", nameSourceFinance);

            return (int)command.ExecuteScalar();
        }
        public int GetFirstIdOrgnizationByName(string name)
        {
            SqlCommand command = new SqlCommand("Select Id_Organization From Organization Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            SqlDataReader reader = command.ExecuteReader();
            List<int> orgIds = new List<int>();
            while (reader.Read())
            {
                orgIds.Add((int)reader["Id_Organization"]);
            }
            reader.Close();

            if (orgIds.Count >= 1)
            {
                int min = orgIds[0];
                for (int i = 1; i < orgIds.Count; i++)
                {
                    if (min >= orgIds[i])
                    {
                        min = orgIds[i];
                    }
                }
                return min;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region AddForOrganization
        public void InsertToOrganization(Organization org)
        {
            SqlCommand command = new SqlCommand("AddOrganization", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", org.Name);
            command.Parameters.AddWithValue("@FullName", org.FullName);
            command.Parameters.AddWithValue("@DateReg", org.DateReg);
            command.Parameters.AddWithValue("@Mission", org.Mission);
            command.Parameters.AddWithValue("@MaterialTechnicalBase", org.MaterialTechnicalBase);
            command.Parameters.AddWithValue("@SettlementAccount", org.SettlementAccount);
            command.Parameters.AddWithValue("@Id_OrganizationLegalForm", org.Id_OrganizationLegalForm);

            command.ExecuteNonQuery();
        }
        public int GetIdLastOrganization()
        {
            SqlCommand command = new SqlCommand("Select * From GetMaxIdOrganization", connection);
            return (int)command.ExecuteScalar();
        }
        public void InsertToPhotoMaterialTechnicalBase(string photo, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into PhotoMaterialTechnicalBase(Photo, Id_Organization) Values (@Photo, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Photo", photo);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();

        }
        public void InsertToTableOrganization_Activity(int idActivity, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Organization_Activity(Id_Activity, Id_Organization) Values (@Id_Activity, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Id_Activity", idActivity);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableOrganization_AvailableService(int idAvailableService, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Organization_AvailableService(Id_AvailableService, Id_Organization) Values (@Id_AvailableService, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Id_AvailableService", idAvailableService);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableOrganization_CategoryOfClient(int idCategoryOfClient, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Organization_CategoryOfClient(Id_CategoryOfClient, Id_Organization) Values (@Id_CategoryOfClient, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Id_CategoryOfClient", idCategoryOfClient);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableOrganization_GeographyOfActivity(int idGeographyOfActivity, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Organization_GeographyOfActivity(Id_GeographyOfActivity, Id_Organization) Values (@Id_GeographyOfActivity, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Id_GeographyOfActivity", idGeographyOfActivity);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableOrganization_SourceFinance(int idSourceFinance, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Organization_SourceFinance(Id_SourceFinance, Id_Organization) Values (@Id_SourceFinance, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Id_SourceFinance", idSourceFinance);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableHeadOrganization(string name, string information, string photo, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into HeadOrganization(Name, Information, Photo, Id_Organization) Values (@Name, @Information, @Photo, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Information", information);
            command.Parameters.AddWithValue("@Photo", photo);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableContact(string typeContact, string valueContact, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Contact(TypeContact, ValueContact, Id_Organization) Values (@TypeContact, @ValueContact, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@TypeContact", typeContact);
            command.Parameters.AddWithValue("@ValueContact", valueContact);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableProject(string nameProject, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into Project(Name, Id_Organization) Values (@Name, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Name", nameProject);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableService(string name, string description, string conditions, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into [Service] (Name, [Description], Conditions, Id_Organization) Values (@Name, @Description, @Conditions, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@Conditions", conditions);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public void InsertToTableGroupPeoples(string name, string information, int idOrg)
        {
            SqlCommand command = new SqlCommand("Insert Into GroupPeoples(Name, Information, Id_Organization) Values (@Name, @Information, @Id_Organization)", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Information", information);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        #endregion

        #region SelectForOrganization

        /// <summary>
        /// Information и Photo мб null
        /// </summary>
        public HeadOrganization GetHeadOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select * From HeadOrganization Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_organization", idOrg);

            SqlDataReader reader = command.ExecuteReader();

            HeadOrganization headOrg = new HeadOrganization();
            if (reader.HasRows == true)
            {
                reader.Read();
                headOrg.Id_HeadOrganization = (int)reader["Id_HeadOrganization"];
                headOrg.Name = (string)reader["Name"];

                if ((DBNull.Value != reader["Information"]) && (reader["Information"] != null))
                {
                    headOrg.Information = (string)reader["Information"];
                }
                else
                {
                    headOrg.Information = null;
                }

                if ((DBNull.Value != reader["Photo"]) && (reader["Photo"] != null))
                {
                    headOrg.Photo = (string)reader["Photo"];
                }
                else
                {
                    headOrg.Photo = null;
                }
            }
            reader.Close();
            return headOrg;
        }

        /// <summary>
        /// Возвращет Type и Value 
        /// </summary>
        public List<Contact> GetContacts(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select TypeContact, ValueContact From Contact Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_organization", idOrg);

            List<Contact> listContacts = new List<Contact>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact();
                contact.TypeContact = (string)reader["TypeContact"];
                contact.ValueContact = (string)reader["ValueContact"];
                listContacts.Add(contact);
            }
            reader.Close();
            return listContacts;
        }
        public List<string> GetProjectsByIdOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select Name From Project Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_organization", idOrg);

            SqlDataReader reader = command.ExecuteReader();

            List<string> listNameOrg = new List<string>();
            while (reader.Read())
            {
                listNameOrg.Add((string)reader["Name"]);
            }
            reader.Close();
            return listNameOrg;
        }
        /// <summary>
        /// Descriptions и Conditions могут быть null
        /// </summary>
        /// <param name="idOrg"></param>
        /// <returns></returns>
        public List<Service> GetServicesByIdORganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select * From Service Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            SqlDataReader reader = command.ExecuteReader();
            List<Service> listServices = new List<Service>();
            while (reader.Read())
            {
                int id = (int)reader["Id_Service"];
                string name = (string)reader["Name"];

                string description;
                if ((DBNull.Value != reader["Description"]) && (reader["Description"] != null))
                {
                    description = (string)reader["Description"];
                }
                else
                {
                    description = null;
                }

                string conditions;
                if ((DBNull.Value != reader["Conditions"]) && (reader["Conditions"] != null))
                {
                    conditions = (string)reader["Conditions"];
                }
                else
                {
                    conditions = null;
                }

                int idOrganization = (int)reader["Id_Organization"];

                listServices.Add(new Service { Id_Service = id, Description = description, Conditions = conditions, Name = name, Id_Organization = idOrganization });
            }
            reader.Close();
            return listServices;
        }

        public string GetPhotoMaterialTechnicalBaseByIdOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select Photo From PhotoMaterialTechnicalBase Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_organization", idOrg);

            return (string)command.ExecuteScalar();
        }
        public List<GroupPeoples> GetGroupsPeoplesByIdOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select * From GroupPeoples Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_organization", idOrg);

            SqlDataReader reader = command.ExecuteReader();
            List<GroupPeoples> listGroups = new List<GroupPeoples>();
            while (reader.Read())
            {
                if (!string.IsNullOrWhiteSpace((string)reader["Information"]))
                {
                    listGroups.Add(new GroupPeoples() { Id_GroupPeoples = (int)reader["Id_GroupPeoples"], Name = (string)reader["Name"], Information = (string)reader["Information"], Id_Organization = idOrg });
                }
            }
            reader.Close();
            return listGroups;
        }

        #endregion


        #region ChangingValuesManyToMany
        public void InsertToOrganizationLegalForm(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into OrganizationLegalForm(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateOrganizationLegalForm(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update OrganizationLegalForm set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteOrganizationLegalForm(string name)
        {
            SqlCommand command = new SqlCommand("Delete From OrganizationLegalForm Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void InsertToActivity(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into Activity(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateActivity(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update Activity set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteActivity(string name)
        {
            SqlCommand command = new SqlCommand("Delete From Activity Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void InsertToCategoryOfClient(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into CategoryOfClient(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateCategoryOfClient(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update CategoryOfClient set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteCategoryOfClient(string name)
        {
            SqlCommand command = new SqlCommand("Delete From CategoryOfClient Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void InsertToAvailableService(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into AvailableService(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateAvailableService(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update AvailableService set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteAvailableService(string name)
        {
            SqlCommand command = new SqlCommand("Delete From AvailableService Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void InsertToGeographyOfActivity(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into GeographyOfActivity(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateGeographyOfActivity(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update GeographyOfActivity set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteGeographyOfActivity(string name)
        {
            SqlCommand command = new SqlCommand("Delete From GeographyOfActivity Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void InsertToSourceFinance(string name)
        {
            SqlCommand command = new SqlCommand("Insert Into SourceFinance(Name) Values (@Name)", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        public void UpdateSourceFinance(string startValue, string endValue)
        {
            SqlCommand command = new SqlCommand("Update SourceFinance set Name = @endName Where Name = @startName", connection);
            command.Parameters.AddWithValue("@endName", endValue);
            command.Parameters.AddWithValue("@startName", startValue);

            command.ExecuteNonQuery();
        }
        public void DeleteSourceFinance(string name)
        {
            SqlCommand command = new SqlCommand("Delete From SourceFinance Where Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);

            command.ExecuteNonQuery();
        }
        #endregion

        public void DeleteOrganization(int idOrg)
        {
            SqlCommand command = new SqlCommand("Delete From Organization Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            command.ExecuteNonQuery();
        }
        public Organization GetOrganizationById(int idOrg)
        {
            SqlCommand command = new SqlCommand("Select * From Organization Where Id_Organization = @Id_Organization", connection);
            command.Parameters.AddWithValue("@Id_Organization", idOrg);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = (int)reader["Id_Organization"];
            string name = (string)reader["Name"];

            string fullName;
            if ((reader["FullName"] != DBNull.Value) && (reader["FullName"] != null))
            {
                fullName = (string)reader["FullName"];
            }
            else
            {
                fullName = null;
            }

            DateTime dateReg;
            if ((reader["DateReg"] != DBNull.Value) && (reader["DateReg"] != null))
            {
                dateReg = (DateTime)reader["DateReg"];
            }
            else
            {
                dateReg = DateTime.Now;
            }

            string mission;
            if ((DBNull.Value != reader["Mission"]) && (reader["Mission"] != null))
            {
                mission = (string)reader["Mission"];
            }
            else
            {
                mission = null;
            }


            string matTechBase;
            if ((DBNull.Value != reader["MaterialTechnicalBase"]) && (reader["MaterialTechnicalBase"] != null))
            {
                matTechBase = (string)reader["MaterialTechnicalBase"];
            }
            else
            {
                matTechBase = null;
            }

            string settlementAccount;
            if ((DBNull.Value != reader["SettlementAccount"]) && (reader["SettlementAccount"] != null))
            {
                settlementAccount = (string)reader["SettlementAccount"];
            }
            else
            {
                settlementAccount = null;
            }

            int idOrgLegForm = -1;
            if ((DBNull.Value != reader["Id_OrganizationLegalForm"]) && (reader["Id_OrganizationLegalForm"] != null))
            {
                idOrgLegForm = (int)reader["Id_OrganizationLegalForm"];
            }
            reader.Close();
            return new Organization() { Id_Organization = id, Name = name, FullName = fullName, DateReg = dateReg, Mission = mission, MaterialTechnicalBase = matTechBase, SettlementAccount = settlementAccount, Id_OrganizationLegalForm = idOrgLegForm };
        }
        public string GetNameOrganizationLegalFormById(int idOrganizationLegalForm)
        {
            SqlCommand command = new SqlCommand("Select Name From OrganizationLegalForm Where Id_OrganizationLegalForm = @idOrganizationLegalForm", connection);
            command.Parameters.AddWithValue("@idOrganizationLegalForm", idOrganizationLegalForm);
            return (string)command.ExecuteScalar();
        }
    }
}

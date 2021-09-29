using System;
using System.Data.SqlClient;
namespace Техническое_задание
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data source=localhost; Initial Catalog=AcademySummer;Integrated Security=True";
            Client client = new Client();
            ApplicationForm form = new ApplicationForm();
            while (true)
            {
                Console.WriteLine("1.Регистрация пользователя");
                Console.WriteLine("2.Добавление заявки на кредит");
                Console.WriteLine("3.Личный кабинет"); int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Регистрация пользователя");
                            Console.Write("Введите номер телефона: "); int tel = int.Parse(Console.ReadLine());
                            client.TelephoneNumber = tel;
                            Console.Clear();

                            Console.WriteLine("Выберите тип пользователя: ");
                            Console.Write("1. Клиент\n2. Администратор\t");
                            switch (choice)
                            {
                                case 1:
                                    client.ClientType = "Клиент";
                                    break;
                                case 2:
                                    client.ClientType = "Администратор";
                                    break;
                                default:
                                    break;
                            }
                            Console.Clear();

                            Console.Write("Пол:\n1.Муж\n2.Жен\t"); choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    client.Gender = "Муж";
                                    client.Balls = 1;
                                    break;
                                case 2:
                                    client.Gender = "Жен";
                                    client.Balls = 2;
                                    break;
                                default:
                                    break;
                            }
                            Console.Clear();

                            Console.Write("Cемейное положение:\n1.холост\n2.семеянин\n3.вразводе\n4.вдовец/вдова\t"); choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    client.MaritalStatus = "холост";
                                    client.Balls += 1;
                                    break;
                                case 2:
                                    client.MaritalStatus = "семеянин";
                                    client.Balls += 2;
                                    break;
                                case 3:
                                    client.MaritalStatus = "вразводе";
                                    client.Balls += 1;
                                    break;
                                case 4:
                                    client.MaritalStatus = "вдовец/вдова";
                                    client.Balls += 2;
                                    break;
                                default:
                                    break;
                            }
                            Console.Clear();

                            Console.Write("возраст: "); choice = int.Parse(Console.ReadLine());
                            client.Age = choice;
                            if (choice < 25)
                            {
                                client.Balls += 0;
                            }
                            if (choice >= 26 && choice <= 35)
                            {
                                client.Balls += 1;
                            }
                            if (choice >= 36 && choice <= 62)
                            {
                                client.Balls += 2;
                            }
                            if (choice > 63)
                            {
                                client.Balls += 1;
                            }
                            Console.Clear();

                            Console.Write("Гражданство:\n1.Таджикистан\n2.Зарубеж\t"); choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    client.Nationality = "Таджикистан";
                                    client.Balls += 1;
                                    break;
                                case 2:
                                    client.Nationality = "Зарубеж";
                                    break;
                                default:
                                    break;
                            }
                            try
                            {
                                AddClient(client, connectionString);
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                            Console.Clear();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите номер телефона: "); int clientTel = int.Parse(Console.ReadLine());
                        try
                        {
                            Console.WriteLine("Введите сумму кредита: "); int s = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите вашу месячную заработку: "); int m = int.Parse(Console.ReadLine());
                            int creditAmount = s / m * 100;
                            form.CreditAmount = creditAmount;
                            form.LoanAmount = s;
                            if (creditAmount < 80)
                            {
                                form.Balls += 4;
                            }
                            if ((creditAmount > 80) & (creditAmount < 150))
                            {
                                form.Balls += 3;
                            }
                            if ((creditAmount > 150) & (creditAmount < 250))
                            {
                                form.Balls += 2;
                            }
                            if (creditAmount > 250)
                            {
                                form.Balls += 1;
                            }
                            Console.Clear();

                            Console.Write("кредитная история: "); int creditStory = int.Parse(Console.ReadLine());
                            form.CreditStory = creditStory;
                            if (creditStory > 3)
                            {
                                form.Balls += 2;
                            }
                            if ((creditStory == 1) | (creditStory == 2))
                            {
                                form.Balls += 1;
                            }
                            if (creditStory == 0)
                            {
                                form.Balls -= 1;
                            }
                            Console.Clear();

                            Console.Write("просрочка в кредитной истории: "); int creditDelay = int.Parse(Console.ReadLine());
                            form.CreditDelay = creditDelay;
                            if (creditDelay > 7)
                            {
                                form.Balls -= 3;
                            }
                            if ((creditDelay >= 5) & (creditDelay <= 7))
                            {
                                form.Balls -= 2;
                            }
                            if (creditDelay == 4)
                            {
                                form.Balls -= 1;
                            }
                            Console.Clear();

                            Console.Write("цель кредита:\n1.бытовая техника\n2.ремонт\n3.телефон\n4.прочее\t"); choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    form.CreditTarget = "бытовая техника";
                                    form.Balls += 2;
                                    break;
                                case 2:
                                    form.CreditTarget = "ремонт";
                                    form.Balls += 1;
                                    break;
                                case 3:
                                    form.CreditTarget = "телефон";
                                    break;
                                case 4:
                                    form.CreditTarget = "прочее";
                                    form.Balls -= 1;
                                    break;
                                default:
                                    break;
                            }
                            Console.Clear();

                            Console.Write("срок кредит: "); int creditTerm = int.Parse(Console.ReadLine());
                            form.CreditTerm = creditTerm;
                            if (creditTerm <= 0)
                            {
                                return;
                            }
                            if (creditTerm > 12)
                            {
                                form.Balls += 1;
                            }
                            if (creditTerm < 12)
                            {
                                form.Balls += 1;
                            }
                            Console.Clear();


                            AddForm(form, clientTel, connectionString);

                            Console.ReadLine();
                            Console.Clear();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Введите номер телефона: "); clientTel = int.Parse(Console.ReadLine());
                        try
                        {
                            PersonalAccountByTel(clientTel, connectionString);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                            Console.ReadLine();
                            Console.Clear();                                            
                        break;
                    default:
                        Console.WriteLine("Command not found!");
                        break;
                }
            }
            Console.ReadLine();
        }

        static void AddClient(Client client, string connString)
        {
            var connection = new SqlConnection(connString);
            var query = $"Insert into Clients(Balls,TelephoneNumber,ClientType,Gender,MaritalStatus,Age,Nationality) " +
                        $"values (@Balls,@TelephoneNumber,@ClientType,@Gender,@MaritalStatus,@Age,@Nationality)";
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Balls", client.Balls);
            command.Parameters.AddWithValue("@TelephoneNumber", client.TelephoneNumber);
            command.Parameters.AddWithValue("@ClientType", client.ClientType);
            command.Parameters.AddWithValue("@Gender", client.Gender);
            command.Parameters.AddWithValue("@MaritalStatus", client.MaritalStatus);
            command.Parameters.AddWithValue("@Age", client.Age);
            command.Parameters.AddWithValue("@Nationality", client.Nationality);

            connection.Open();
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Клиент успешно добавлен.");
                Console.ReadLine();
            }
            connection.Close();
        }
        static void AddForm(ApplicationForm form, int tel, string connString)
        {
            var connection = new SqlConnection(connString);
            var query = $"Insert into ApplicationForm(ClientsId,Balls,CreatedAt,CreditAmount,LoanAmount,CreditStory,CreditDelay,CreditTarget,CreditTerm)" +
                        $"values ((Select Id from Clients where TelephoneNumber={tel}),@Balls,@CreatedAt,@CreditAmount,@LoanAmount,@CreditStory,@CreditDelay,@CreditTarget,@CreditTerm)";
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            command.Parameters.AddWithValue("@Balls", form.Balls);
            command.Parameters.AddWithValue("@CreditAmount", form.CreditAmount);
            command.Parameters.AddWithValue("@LoanAmount", form.LoanAmount);
            command.Parameters.AddWithValue("@CreditStory", form.CreditStory);
            command.Parameters.AddWithValue("@CreditDelay", form.CreditDelay);
            command.Parameters.AddWithValue("@CreditTarget", form.CreditTarget);
            command.Parameters.AddWithValue("@CreditTerm", form.CreditTerm);
            connection.Open();
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Заявка успешно добавлена.");
            }
            command.CommandText = $"select Balls from Clients where TelephoneNumber={tel} ";
            int clientBalls = (int)command.ExecuteScalar();
            if ((clientBalls + form.Balls) > 11)
            {
                double p = 0.01;
                double monthlyPayment = (form.LoanAmount * (p + (p / (Math.Pow(1 + p, form.CreditTerm) - 1))));

                command.CommandText = $"insert into Credits(ClientsId,CreatedAt,MonthlyPayment,Term) " +
                                      $"values ((select Id from Clients where TelephoneNumber={tel}),@Created_At,@MonthlyPayment,@Term)";
                //command.Parameters.AddWithValue("@ApplicationFormId", form.Id);
                command.Parameters.AddWithValue("@Created_At", DateTime.Now);
                command.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
                command.Parameters.AddWithValue("@Term", form.CreditTerm);

                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Кредит успешно добавлен.");
                }
            }
            connection.Close();
        }
        static void PersonalAccountByTel(int tel, string connString)
        {
            var connection = new SqlConnection(connString);
            var query = $"select Id,CreatedAt,MonthlyPayment,Term  from Credits  where ClientsId = (select Id from Clients where TelephoneNumber={tel})";
            var command = connection.CreateCommand();
            command.CommandText = query;
            connection.Open();
            var sqlReader = command.ExecuteReader();
            Console.WriteLine("Список кредитов:");
            if (sqlReader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", sqlReader.GetName(0), sqlReader.GetName(1), sqlReader.GetName(2), sqlReader.GetName(3));

                while (sqlReader.Read())
                {
                    var Id = sqlReader.GetValue(0);
                    DateTime CreatedAt = (DateTime)sqlReader.GetValue(1);
                    var MonthlyPayment = Math.Round((double)sqlReader.GetValue(2), 2);
                    var Term = sqlReader.GetValue(3);
                    
                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}", Id, CreatedAt.ToShortDateString(), MonthlyPayment,Term);
                }
            }
            sqlReader.Close();
            command.CommandText = $"select Id, CreatedAt, LoanAmount, CreditStory,CreditDelay, CreditTarget, CreditTerm" +
                                  $" from ApplicationForm where ClientsId=(select Id from Clients where TelephoneNumber={tel})";
            sqlReader = command.ExecuteReader();
            Console.WriteLine("\nСписок заявок:");
            if (sqlReader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", sqlReader.GetName(0), sqlReader.GetName(1), sqlReader.GetName(2), sqlReader.GetName(3), sqlReader.GetName(4),sqlReader.GetName(5), sqlReader.GetName(6));

                while (sqlReader.Read())
                {
                    var Id = sqlReader.GetValue(0);
                    DateTime CreatedAt =(DateTime) sqlReader.GetValue(1);
                    var LoanAmount = sqlReader.GetValue(2);
                    var CreditStory = sqlReader.GetValue(3);
                    var CreditDelay = sqlReader.GetValue(4);
                    var CreditTarget = sqlReader.GetValue(5);
                    var CreditTerm = sqlReader.GetValue(6);

                    Console.WriteLine("{0}\t{1}\t     {2}\t{3}\t\t{4}\t\t{5}\t\t{6}", Id, CreatedAt.ToShortDateString(),LoanAmount,CreditStory,CreditDelay,CreditTarget,CreditTerm );
                }
            }
            sqlReader.Close();

            connection.Close();
        }
    }
}

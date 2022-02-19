using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    static class AdatbazisKezelo
    {
        static SqlConnection connection;
        static SqlCommand command;

        static void Csatlakozas()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["AllatNyilvantartoConStr"].ConnectionString;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A csatlakozás sikertelen!", ex);
            }
        }

        static void KapcsolatBontas()
        {
            try
            {
                connection.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A kapcsolat bontása sikertelen!", ex);
            }
        }

        public static void AllatFelvitel(Gondozo gondozo, Allat uj)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "INSERT INTO [Allat] VALUES (@nev, @chip, @leiras, @szor, @nem, @suly, @szulev, @bekerules, @ivart, @macs, @kuty, @gyerek, @gazd, @gid)";
                command.Parameters.AddWithValue("@nev", uj.Nev);
                command.Parameters.AddWithValue("@chip", uj.Chipszam);
                command.Parameters.AddWithValue("@leiras", uj.Leiras);
                command.Parameters.AddWithValue("@szor", (int)uj.Szor);
                command.Parameters.AddWithValue("@nem", (int)uj.Nem);
                command.Parameters.AddWithValue("@suly", uj.Suly);
                command.Parameters.AddWithValue("@szulev", uj.SzuletesiDatum);
                command.Parameters.AddWithValue("@bekerules", uj.BekerulesiDatum);
                command.Parameters.AddWithValue("@ivart", uj.Ivartalanitott);
                command.Parameters.AddWithValue("@macs", uj.MacskavalTarthato);
                command.Parameters.AddWithValue("@kuty", uj.KutyavalTarthato);
                command.Parameters.AddWithValue("@gyerek", uj.GyerekkelTarthato);
                command.Parameters.AddWithValue("@gazd", uj.Gazdas);
                command.Parameters.AddWithValue("@gid", gondozo.Id);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@nev", uj.Nev);
                if (uj is Kutya kutya)
                {
                    command.CommandText = "INSERT INTO [Kutya] VALUES (@nev, @szoba, @lakas, @egye)";
                    command.Parameters.AddWithValue("@szoba", kutya.Szobatiszta);
                    command.Parameters.AddWithValue("@lakas", kutya.LakasbanTarthato);
                    command.Parameters.AddWithValue("@egye", kutya.EgyedulHagyhato);
                }
                else if (uj is Macska macska)
                {
                    command.CommandText = "INSERT INTO [Macska] VALUES (@nev, @kij)";
                    command.Parameters.AddWithValue("@kij", macska.Kijaros);
                }
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban! Értesitse a rendszergazdát!", ex2);
                }
                throw new ABKivetel("Az állat felvitele sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void AllatModositas(Allat modosit)
        {
            Csatlakozas();
            try
            {
                command.CommandText = "UPDATE [Allat] SET [Chipszam] = @chip, [Leiras] = @leir, [Szor] = @szor, [Suly] = @suly, [Ivartalanitott] = @ivar, [MacskavalTarthato] = @macs, [KutyavalTarthato] = @kuty, [GyerekkelTarthato] = @gyer, [Gazdas] = @gazd WHERE [Nev] = @nev";
                command.Parameters.AddWithValue("@chip", modosit.Chipszam);
                command.Parameters.AddWithValue("@leir", modosit.Leiras);
                command.Parameters.AddWithValue("@szor", modosit.Szor);
                command.Parameters.AddWithValue("@suly", modosit.Suly);
                command.Parameters.AddWithValue("@ivar", modosit.Ivartalanitott);
                command.Parameters.AddWithValue("@macs", modosit.MacskavalTarthato);
                command.Parameters.AddWithValue("@kuty", modosit.KutyavalTarthato);
                command.Parameters.AddWithValue("@gyer", modosit.GyerekkelTarthato);
                command.Parameters.AddWithValue("@gazd", modosit.Gazdas);
                command.Parameters.AddWithValue("@nev", modosit.Nev);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@nev", modosit.Nev);
                if (modosit is Kutya kutya)
                {
                    command.CommandText = "UPDATE [Kutya] SET [Szobatiszta] = @szoba, [LakasbanTarthato] = @lak, [EgyedulHagyhato] = @egy WHERE [Nev] = @nev";
                    command.Parameters.AddWithValue("@szoba", kutya.Szobatiszta);
                    command.Parameters.AddWithValue("@lak", kutya.LakasbanTarthato);
                    command.Parameters.AddWithValue("@egy", kutya.EgyedulHagyhato);
                }
                else if (modosit is Macska macska)
                {
                    command.CommandText = "UPDATE [Macska] SET [Kijaros] = @kij WHERE [Nev] = @nev";
                    command.Parameters.AddWithValue("@kij", macska.Kijaros);
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Az állat módosítása sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void AllatTorles(Allat torol)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = $"DELETE FROM [{((torol is Kutya) ? "Kutya" : "Macska")}] WHERE [Nev] = @nev";
                command.Parameters.AddWithValue("@nev", torol.Nev);
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM [Allat] WHERE [Nev] = @nev";
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }

                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban! Értesítse a rendszergazdát!", ex2);
                }
                throw new ABKivetel("Az állat törlése sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void GondozoFelvitel(Gondozo uj)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "INSERT INTO [Gondozo]([Nev], [SzuletesiDatum]) OUTPUT INSERTED.Id VALUES (@nev, @szul)";
                command.Parameters.AddWithValue("@nev", uj.Nev);
                command.Parameters.AddWithValue("@szul", uj.SzuletesiDatum);
                uj.Id = (int)command.ExecuteScalar();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban! Értesitse a rendszergazdát!", ex2);
                }
                throw new ABKivetel("A gondozó felvitele sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadoFelvitele(Orokbefogado uj)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "INSERT INTO [Orokbefogado]([Nev], [Lakcim], [SzuletesiDatum], [Email]) OUTPUT INSERTED.Id VALUES (@nev, @cim, @szul, @email)";
                command.Parameters.AddWithValue("@nev", uj.Nev);
                command.Parameters.AddWithValue("@cim", uj.Lakcim);
                command.Parameters.AddWithValue("@szul", uj.SzuletesiDatum);
                command.Parameters.AddWithValue("@email", uj.Email);
                uj.Id = (int)command.ExecuteScalar();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban! Értesitse a rendszergazdát!", ex2);
                }
                throw new ABKivetel("Az örökbefogadó felvitele sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadasFelvitele(Orokbefogado orokbefogado, Allat allat, Orokbefogadas uj)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "INSERT INTO [Orokbefogadas]([OrokbefogadasDatuma], [UtoellenorzesDatuma], [UtoellenorzesSikeres],[OrokbefogadoID], [AllatID]) OUTPUT INSERTED.Id VALUES (@orok, @uto, @sik, @oid, @aid)";
                command.Parameters.AddWithValue("@orok", uj.OrokbefogadasDatuma);
                command.Parameters.AddWithValue("@uto", uj.UtoellenorzesDatuma);
                command.Parameters.AddWithValue("@sik", uj.SikeresUtoellenorzes);
                command.Parameters.AddWithValue("@oid", orokbefogado.Id);
                command.Parameters.AddWithValue("@aid", allat.Nev);
                uj.Id = (int)command.ExecuteScalar();
                command.Transaction.Commit();


                if (allat is Kutya)
                {
                    PDFGenerator.PDF(uj.Id.ToString(), orokbefogado.Nev.ToString(), orokbefogado.Lakcim.ToString(), orokbefogado.Email.ToString(), "kutya", allat.Nev.ToString(), allat.Chipszam.ToString(), DateTime.Today.ToString("yyyy.MM.dd"));
                }
                else if (allat is Macska)
                {
                    PDFGenerator.PDF(uj.Id.ToString(), orokbefogado.Nev.ToString(), orokbefogado.Lakcim.ToString(), orokbefogado.Email.ToString(), "macska", allat.Nev.ToString(), allat.Chipszam.ToString(), DateTime.Today.ToString("yyyy.MM.dd"));
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban! Értesitse a rendszergazdát!", ex2);
                }
                throw new ABKivetel("Az örökbefogadás felvitele sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadasModositas(Orokbefogado orokbefogado, Allat allat, Orokbefogadas modosit)
        {
            Csatlakozas();
            try
            {
                command.CommandText = "UPDATE [Orokbefogadas] SET [OrokbefogadasDatuma] = @orok, [UtoellenorzesDatuma] = @uto, [UtoellenorzesSikeres] = @sik, [OrokbefogadoID] = @oid WHERE [AllatID] = @nev";
                command.Parameters.AddWithValue("@orok", modosit.OrokbefogadasDatuma);
                command.Parameters.AddWithValue("@uto", modosit.UtoellenorzesDatuma);
                command.Parameters.AddWithValue("@sik", modosit.SikeresUtoellenorzes);
                command.Parameters.AddWithValue("@oid", orokbefogado.Id);
                command.Parameters.AddWithValue("@nev", allat.Nev);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Az örökbefogadás módosítása sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }
        //TODO orokbefogadas modositas
        public static Orokbefogadas OrokbefogadasFelolvasas(Allat allat)
        {
            Orokbefogadas orokbefogadas;
            Csatlakozas();
            try
            {
                //command.CommandText = "SELECT * FROM [Orokbefogadas] WHERE [AllatID] = @nev";
                //command.Parameters.AddWithValue("@nev", allat.Nev);
                command.CommandText = "SELECT *,[AllatID] AS [Allatnev] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = [Allat].[Nev]";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    orokbefogadas = new Orokbefogadas((DateTime)reader["OrokbefogadasDatuma"], (DateTime)reader["UtoellenorzesDatuma"], (bool)reader["UtoellenorzesSikeres"]);
                }
                return orokbefogadas;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
        }

        // TODO timer
        //public static DateTime UtoellenorzesKiolvasas()
        //{
        //    DateTime utoellDatum;
        //    Csatlakozas();
        //    try
        //    {
        //        command.CommandText = "SELECT [UtoellenorzesDatuma],[AllatID] AS [Allatnev] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = [Allat].[Nev]";
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {

        //            utoellDatum = (DateTime)reader["UtoellenorzesDatuma"];

        //            //reader.Close();
        //        }
        //        return utoellDatum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ABKivetel("A lekérdezés sikertelen!", ex);
        //    }
        //}

        public static List<string> UtoellenorzesEsedekes() 
        {
            List<string> utoellEsedekes = new List<string>();
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT [UtoellenorzesDatuma],[AllatID] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = [Allat].[Nev] WHERE [UtoellenorzesDatuma] < (GETDATE() +3)";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        utoellEsedekes.Add(reader["AllatID"].ToString());
                    }
                    reader.Close();
                }
                return utoellEsedekes;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
            finally 
            { 
                KapcsolatBontas();
            }
        }

        public static List<Gondozo> GondozokFelolvasas()
        {
            List<Gondozo> gondozok = new List<Gondozo>();
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT * FROM [Gondozo]";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (gondozok.Count == 0 || gondozok.Last().Id != (int)reader["Id"])
                        {
                            gondozok.Add(new Gondozo((int)reader["Id"], reader["Nev"].ToString(), (DateTime)reader["SzuletesiDatum"]));
                        }
                    }
                    reader.Close();
                }
                return gondozok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static List<Allat> AllatokFelolvasas()
        {
            List<Allat> allatok = new List<Allat>();
            List<Gondozo> gondozok = AdatbazisKezelo.GondozokFelolvasas();
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT *, [Kutya].[Nev] AS [Kutyanev], [Macska].[Nev] AS [Macskanev] FROM [Allat] LEFT JOIN [Kutya] ON [Allat].[Nev] = [Kutya].[Nev] LEFT JOIN [Macska] ON [Allat].[Nev] = [Macska].[Nev]";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Kutyanev")))
                        {
                            allatok.Add(new Kutya(
                                reader["Nev"].ToString(),
                                reader["Chipszam"].ToString(),
                                reader["Leiras"].ToString(),
                                (Szor)(int)reader["Szor"],
                                (Nem)(int)reader["Nem"],
                                (double)reader["Suly"],
                                (DateTime)reader["SzuletesiDatum"],
                                (DateTime)reader["BekerulesiDatum"],
                                bool.Parse(reader["Ivartalanitott"].ToString()),
                                bool.Parse(reader["MacskavalTarthato"].ToString()),
                                bool.Parse(reader["KutyavalTarthato"].ToString()),
                                bool.Parse(reader["GyerekkelTarthato"].ToString()),
                                bool.Parse(reader["Szobatiszta"].ToString()),
                                bool.Parse(reader["LakasbanTarthato"].ToString()),
                                bool.Parse(reader["EgyedulHagyhato"].ToString()),
                                bool.Parse(reader["Gazdas"].ToString()),
                                gondozok.FirstOrDefault(x => x.Id == (int)reader["GondozoID"])
                                ));
                        }
                        else if (!reader.IsDBNull(reader.GetOrdinal("Macskanev")))
                        {
                            allatok.Add(new Macska(
                                reader["Nev"].ToString(),
                                reader["Chipszam"].ToString(),
                                reader["Leiras"].ToString(),
                                (Szor)(int)reader["Szor"],
                                (Nem)(int)reader["Nem"],
                                (double)reader["Suly"],
                                (DateTime)reader["SzuletesiDatum"],
                                (DateTime)reader["BekerulesiDatum"],
                                bool.Parse(reader["Ivartalanitott"].ToString()),
                                bool.Parse(reader["MacskavalTarthato"].ToString()),
                                bool.Parse(reader["KutyavalTarthato"].ToString()),
                                bool.Parse(reader["GyerekkelTarthato"].ToString()),
                                bool.Parse(reader["Kijaros"].ToString()),
                                bool.Parse(reader["Gazdas"].ToString()),
                                gondozok.FirstOrDefault(x => x.Id == (int)reader["GondozoID"])
                                ));
                        }
                    }
                    reader.Close();
                }
                return allatok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static List<Orokbefogado> OrokbefogadokFelolvasas()
        {
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT * FROM [Orokbefogado]";
                List<Orokbefogado> orokbefogadok = new List<Orokbefogado>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (orokbefogadok.Count == 0 || orokbefogadok.Last().Id != (int)reader["Id"])
                        {
                            orokbefogadok.Add(new Orokbefogado((int)reader["Id"], reader["Nev"].ToString(), reader["Lakcim"].ToString(), reader["Email"].ToString(), (DateTime)reader["SzuletesiDatum"]));
                        }
                    }
                    reader.Close();
                }
                return orokbefogadok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }
    }
}

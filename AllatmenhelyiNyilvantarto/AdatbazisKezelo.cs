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

        public static void GondozoModositas(Gondozo modosit)
        {
            Csatlakozas();
            try
            {
                command.CommandText = "UPDATE [Gondozo] SET [Nev] = @nev WHERE [Id] = @id";
                command.Parameters.AddWithValue("@nev", modosit.Nev);
                command.Parameters.AddWithValue("@id", modosit.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A gondozó módosítása sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadoFelvitel(Orokbefogado uj)
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

        public static void OrokbefogadoModositas(Orokbefogado modosit)
        {
            Csatlakozas();
            try
            {
                command.CommandText = "UPDATE [Orokbefogado] SET [Nev] = @nev, [Lakcim] = @cim, [Email] = @email WHERE [Id] = @id";
                command.Parameters.AddWithValue("@nev", modosit.Nev);
                command.Parameters.AddWithValue("@cim", modosit.Lakcim);
                command.Parameters.AddWithValue("@email", modosit.Email);
                command.Parameters.AddWithValue("@id", modosit.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Az örökbefogadó módosítása sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadoTorles(Orokbefogado torol)
        {
            Csatlakozas();
            try
            {
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "DELETE FROM [Orokbefogado] WHERE [Id] = @id";
                command.Parameters.AddWithValue("@id", torol.Id);
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
                throw new ABKivetel("Az örökbefogadó törlése sikertelen!", ex);
            }
            finally
            {
                KapcsolatBontas();
            }
        }

        public static void OrokbefogadasFelvitel(Orokbefogado orokbefogado, Allat allat, Orokbefogadas uj)
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

        public static void OrokbefogadasModositas(Allat allat, Orokbefogadas modosit)
        {
            Csatlakozas();
            try
            {
                command.CommandText = "UPDATE [Orokbefogadas] SET [UtoellenorzesDatuma] = @uto, [UtoellenorzesSikeres] = @sik WHERE [AllatID] = @nev";
                command.Parameters.AddWithValue("@uto", modosit.UtoellenorzesDatuma);
                command.Parameters.AddWithValue("@sik", modosit.SikeresUtoellenorzes);
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

        public static Orokbefogadas OrokbefogadasFelolvasas(Allat allat)
        {
            Orokbefogadas orokbefogadas = null;
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT *,[AllatID] AS [Allatnev] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = @nev";
                command.Parameters.AddWithValue("@nev", allat.Nev);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Allatnev")))
                        {
                            orokbefogadas = new Orokbefogadas((DateTime)reader["OrokbefogadasDatuma"], (DateTime)reader["UtoellenorzesDatuma"], (bool)reader["UtoellenorzesSikeres"]);
                        } 
                    }
                }
                return orokbefogadas;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A lekérdezés sikertelen!", ex);
            }
        }

        public static Orokbefogado OrokbefogadoKiolvasas(Allat allat)
        {
            int id = -1;
            Orokbefogado orokbefogado = null;
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT [OrokbefogadoID], [AllatID] AS [Allatnev] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = @nev";
                command.Parameters.AddWithValue("@nev", allat.Nev);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Allatnev")))
                        {
                            id = (int)reader["OrokbefogadoID"];
                        }
                    }
                    reader.Close();
                }
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM [Orokbefogado] WHERE [Id] = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (id != -1)
                        {
                            orokbefogado = new Orokbefogado(reader["Nev"].ToString(), reader["Lakcim"].ToString(), reader["Email"].ToString(), (DateTime)reader["SzuletesiDatum"]);
                        }
                    }
                    reader.Close ();
                }
                return orokbefogado;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A kiolvasás sikertelen!", ex);
            }
        }

        public static List<string> UtoellenorzesEsedekes()
        {
            List<string> utoellEsedekes = new List<string>();
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT [UtoellenorzesDatuma],[UtoellenorzesSikeres], [AllatID] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = [Allat].[Nev] WHERE [UtoellenorzesSikeres] <> 1 AND [UtoellenorzesDatuma] < (GETDATE() +3)";
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

        public static List<string> UtoellenorzesSikeres()
        {
            List<string> utoellSikeres = new List<string>();
            Csatlakozas();
            try
            {
                command.CommandText = "SELECT [UtoellenorzesSikeres],[AllatID] FROM [Orokbefogadas] LEFT JOIN [Allat] ON [Orokbefogadas].[AllatID] = [Allat].[Nev] WHERE [UtoellenorzesSikeres] = 1";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        utoellSikeres.Add(reader["AllatID"].ToString());
                    }
                    reader.Close();
                }
                return utoellSikeres;
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

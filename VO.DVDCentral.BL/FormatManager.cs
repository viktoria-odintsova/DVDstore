using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class FormatManager
    {
        public static int Insert(out int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat newrow = new tblFormat();

                    newrow.Description = description;

                    newrow.Id = dc.tblFormats.Any() ? dc.tblFormats.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblFormats.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Format format)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, format.Description);
                format.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat deleterow = (from dt in dc.tblFormats
                                           where dt.Id == id
                                           select dt).FirstOrDefault();
                    dc.tblFormats.Remove(deleterow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat updaterow = (from dt in dc.tblFormats
                                           where dt.Id == id
                                           select dt).FirstOrDefault();

                    updaterow.Description = description;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Format format)
        {
            return Update(format.Id, format.Description);
        }

        public static List<Format> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Format> formats = new List<Format>();
                    foreach (tblFormat dt in dc.tblFormats)
                    {
                        formats.Add(new Format
                        {
                            Id = dt.Id,
                            Description = dt.Description
                        });
                    }
                return formats;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Format LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat row = (from dt in dc.tblFormats
                                     where dt.Id == id
                                     select dt).FirstOrDefault();

                    if (row != null)
                        return new Format { Id = row.Id, Description = row.Description };
                    else
                        throw new Exception("Row was not found");


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

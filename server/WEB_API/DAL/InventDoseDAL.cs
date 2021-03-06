﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class InventDoseDAL
    {
        //get all
        public static List<InventDose> GetAll()
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                return db.InventDose.ToList();
            }
        }
        public static List<SpecialInvent> GetAllSpecialInvent()
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                return db.SpecialInvent.ToList();
            }
        }
        //get by id
        public static List<InventDetails> GetByIdInventDetails(int id)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var invents = db.InventDetails.Where(i => i.IdDose == id).ToList();
                return invents;
            }
        }
        public static List<InventDose> GetDoseByfeedback()
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var invents = db.InventDose.Where(i => i.Feedback != null).ToList();
                return invents;
            }
        }
        public static StatusInvent GetByIdStatusInvent(int id)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var status = db.StatusInvent.Find(id);
                return status;
            }
        }
        public static List<InventDose> GetById(int id)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var invents = db.InventDose.Where(v => v.IdVisiter == id).ToList();
               // invents.ForEach(v => v.InventDetails = v.InventDetails.ToList());
                return invents;
            }
        }
        //add
        public static InventDose Add(InventDose inventDose)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                inventDose.DateInvent = DateTime.Now;
                var inventDose1 = db.InventDose.Add(inventDose);
                db.SaveChanges();
                //foreach (var item in inventDose.InventDetails)
                //{
                //    item.InventDose = null;
                //    item.IdDose = inventDose1.Id;
                //    db.InventDetails.Add(item);
                //    db.SaveChanges();
                //}
                //db.InventDetails.AddRange(db.InventDetails);
                return inventDose;
            }
        }


        public static void AddSpecialInvent(SpecialInvent specialInvent)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                db.SpecialInvent.Add(specialInvent);
                db.SaveChanges();
            }
        }
        public static void Addfeedback(InventDose inventDose)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var dose = db.InventDose.FirstOrDefault(d => d.Id == inventDose.Id);
                dose.Feedback = inventDose.Feedback;
                db.SaveChanges();
            }
        }
        //update
        public static void UpdateIdStatus(InventDose inventDose)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var dose = db.InventDose.FirstOrDefault(d => d.Id == inventDose.Id);
                if (dose.IdStatusDose == 3)
                    dose.IdStatusDose = 1;
                else
                    dose.IdStatusDose = 2;
                db.SaveChanges();
            }
        }
        public static void Update(InventDose inventDose)
        {

            using (restaurantEntities db = new restaurantEntities())
            {
                db.Entry(inventDose).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //delete
        public static void Delete(InventDose inventDose)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                db.InventDose.Remove(inventDose);
                db.SaveChanges();
            }
        }
        public static void UpdateSpecialInvent(SpecialInvent specialInvent)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var o = db.SpecialInvent.Single(so => so.Id == specialInvent.Id);
                o.isContact = true;
                db.SaveChanges();
            }
        }
        public static void DeleteSpecialInvent(SpecialInvent specialInvent)
        {
            using (restaurantEntities db = new restaurantEntities())
            {
                var o = db.SpecialInvent.Single(so => so.Id == specialInvent.Id);
                db.SpecialInvent.Remove(o);
                db.SaveChanges();
            }
        }
    }
}


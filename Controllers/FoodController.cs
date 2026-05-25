using Microsoft.AspNetCore.Mvc;
using Food_and_Grains.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Food_and_Grains.Controllers
{
    public class FoodController : Controller
    {
        static List<FoodItem> foodList = new List<FoodItem>()
        {
            new FoodItem { Id=1, Name="Wheat", Category="Grain", Quantity=100, AddedDate=DateTime.Now, ImagePath="/images/wheat.jpg"},
            new FoodItem { Id=2, Name="Rice", Category="Grain", Quantity=80, AddedDate=DateTime.Now, ImagePath="/images/rice.jpg"},
            new FoodItem { Id=3, Name="Dal", Category="Pulses", Quantity=50, AddedDate=DateTime.Now, ImagePath="/images/dal.jpg"},
            new FoodItem { Id=4, Name="Sugar", Category="Sweetener", Quantity=40, AddedDate=DateTime.Now, ImagePath="/images/sugar.jpg"},
            new FoodItem { Id=5, Name="Oil", Category="Cooking", Quantity=30, AddedDate=DateTime.Now, ImagePath="/images/oil.jpg"}
        };

        public IActionResult Index()
        {
            return View(foodList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FoodItem item)
        {
            item.Id = foodList.Count + 1;
            item.AddedDate = DateTime.Now;

            foodList.Add(item);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var item = foodList.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = foodList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                foodList.Remove(item);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = foodList.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(FoodItem item)
        {
            var existing = foodList.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Category = item.Category;
                existing.Quantity = item.Quantity;
            }
            return RedirectToAction("Index");
        }
    }
}

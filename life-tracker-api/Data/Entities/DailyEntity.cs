﻿using Enums;
using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class DailyEntity
    {
       
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public ItemType ItemType { get; set; }
        public List<ItemTagsEntity> Tags { get; set; }
        public bool IsComplete { get; set; }
        public int? SeriesId { get; set; }
        public Reiteration Reiteration { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<DailySubtaskEntity> Subtasks { get; set; }
        public DailyEntity()
        {
            Tags = new List<ItemTagsEntity>();
            Subtasks = new List<DailySubtaskEntity>();
        }
    }
}

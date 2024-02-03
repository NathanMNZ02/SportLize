﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLize.Profile.Api.Profile.Repository.Model
{
	public class PostInterest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Gym
        public bool BodyBuilding { get; set; }
        public bool PowerLifting { get; set; }
        public bool CrossFit { get; set; }
        public bool Calisthenics { get; set; }

        //Water
        public bool Swimming { get; set; }
        public bool Surfing { get; set; }
        public bool Kayaking { get; set; }
        public bool Snorkeling { get; set; }

        //Snow
        public bool Skiing { get; set; }
        public bool Snowboarding { get; set; }
        public bool IceSkating { get; set; }

        //Other
        public bool Yoga { get; set; }
        public bool Pilates { get; set; }
        public bool Running { get; set; }
        public bool Cycling { get; set; }
        public bool MartialArts { get; set; }
        public bool RockClimbing { get; set; }

        //Post Mapping
        public required Post Post { get; set; }
        public required int PostId { get; set; }
    }
}


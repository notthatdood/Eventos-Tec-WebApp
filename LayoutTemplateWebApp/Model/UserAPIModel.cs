﻿
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Model
{
    public class UserAPIModel
    {

        [Key]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("personName")]
        public string PersonName { get; set; }

        [JsonPropertyName("firstLastName")]
        public string FirstLastName { get; set; }

        [JsonPropertyName("secondLastName")]
        public string SecondLastName { get; set; }

        [JsonPropertyName("debt")]
        public decimal Debt { get; set; }

        [JsonPropertyName("employee")]
        public Employee Employee { get; set; } // Assuming Employee can be a complex object

        [JsonPropertyName("student")]
        public Student Student { get; set; }

        [JsonPropertyName("departments")]
        public List<Object> Departments { get; set; } // Assuming Department is a list of string

        [JsonPropertyName("schools")]
        public List<Object> Schools { get; set; }     // Assuming School is a list of string

        [JsonPropertyName("applicationRoles")]
        public List<ApplicationRole> ApplicationRoles { get; set; }
    }
}
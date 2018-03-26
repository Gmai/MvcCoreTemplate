using CrossCutting.DataAnnotations;
using CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossCutting.Models
{
	public class Field 
	{
		public object Value { get; set; }
		public FieldType Type { get; set; }
		public bool Required { get; set; }
		public string Label { get; set; }
		public List<FieldRule> Rules { get; set; }

		public Field()
		{
			Rules = new List<FieldRule>();
		}

		public static List<Field> Extract(object model) {
			List<Field> fields = new List<Field>();
			var type = model.GetType();
			var properties = model.GetType().GetProperties();
			foreach (var property in properties)
			{
				var attributes = property.GetCustomAttributes(false);
				var fieldAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(FieldAttribute));
				if (fieldAttribute != null)
				{
					var field = (fieldAttribute as FieldAttribute).GetFieldData();
					fields.Add(field);
				}
			}
			return fields;
		}
	}
}

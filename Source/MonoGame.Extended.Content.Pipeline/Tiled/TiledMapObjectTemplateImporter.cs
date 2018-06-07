﻿using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MonoGame.Extended.Content.Pipeline.Tiled
{
	[ContentImporter(".tx", DefaultProcessor = "TiledMapObjectTemplateProcessor", DisplayName = "Tiled Map Object Template Importer - MonoGame.Extended")]
	public class TiledMapObjectTemplateImporter : ContentImporter<TiledMapObjectTemplateContent>
	{
		public override TiledMapObjectTemplateContent Import(string filePath, ContentImporterContext context)
		{
			try
			{
				if (filePath == null)
					throw new ArgumentNullException(nameof(filePath));

				ContentLogger.Logger = context.Logger;
				ContentLogger.Log($"Importing '{filePath}'");

				var template = DeserializeTileMapObjectTemplateContent(filePath, context);

				ContentLogger.Log($"Imported '{filePath}'");

				return template;
			}
			catch (Exception e)
			{
				foreach (var data in e.Data)
					context.Logger.LogImportantMessage(data.ToString());
				context.Logger.LogImportantMessage(e.StackTrace);
				return null;
			}
		}

		private TiledMapObjectTemplateContent DeserializeTileMapObjectTemplateContent(string filePath, ContentImporterContext context)
		{
			using (var reader = new StreamReader(filePath))
			{
				var templateSerializer = new XmlSerializer(typeof(TiledMapObjectTemplateContent));
				var template = (TiledMapObjectTemplateContent)templateSerializer.Deserialize(reader);

				if (!String.IsNullOrWhiteSpace(template.Tileset?.Source))
					context.AddDependency(template.Tileset.Source);

				return template;
			}
		}
	}
}

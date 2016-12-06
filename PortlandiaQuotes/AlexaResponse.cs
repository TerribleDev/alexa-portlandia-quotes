﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlexaSkillsKit.Authentication;
using AlexaSkillsKit.Json;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace PortlandiaQuotes
{
	public class AlexaResponse : Speechlet
	{


		public override SpeechletResponse OnIntent(IntentRequest intentRequest, Session session)
		{
			return CompileResponse();
		}

		public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
		{
			return CompileResponse();
		}

		public override bool OnRequestValidation(SpeechletRequestValidationResult result, DateTime referenceTimeUtc, SpeechletRequestEnvelope requestEnvelope)
		{
			if(requestEnvelope?.Session?.Application?.Id?.Equals("amzn1.ask.skill.6d1ea9ba-fcf9-4ccb-b7cc-68b6ee8f8bcd") == false)
			{
				return false;
			}
			return base.OnRequestValidation(result, referenceTimeUtc, requestEnvelope);
		}

		public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
		{
		}

		public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
		{
		}
		public static SpeechletResponse CompileResponse()
		{
			var excuse = GetExcuse();
			return new SpeechletResponse()
			{
				OutputSpeech = new PlainTextOutputSpeech() { Text = excuse },
				ShouldEndSession = true
			};
		}
		public static string GetExcuse()
		{
			// Setup the configuration to support document loading
			var item = new Random().Next(0, Items.ItemsList.Count);
			return Items.ItemsList[item];
		}
	}
}
﻿using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using Microsoft.AspNetCore.Http;

namespace Tests
{
    public class BasicAutoDataAttribute : AutoDataAttribute
    {
        public BasicAutoDataAttribute() : base(CreateFixture)
        {

        }

        private static IFixture CreateFixture()
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization
            {
                ConfigureMembers = true,
                GenerateDelegates = true
            });

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize<HttpResponse>(r => r.Without(p => p.Body));

            return fixture;
        }
    }
}
﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {

            var targerConditions = new List<int>() { 1, 2, 3, 4 };

            RuleFor(post => post.Target)
                .NotEmpty()
                .Must(conditions =>
                    targerConditions.Contains(conditions)).WithMessage("Please only use: " + String.Join(", ", targerConditions));
        }
    }
}

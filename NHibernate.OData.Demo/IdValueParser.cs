﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernate.OData.Demo
{
    internal class IdValueParser : Parser
    {
        public IdValueParser(string source)
            : base(source, ParserMode.Normal)
        {
        }

        public object Parse()
        {
            var result = ParseCommon();

            ExpectAtEnd();

            result.Visit(new AliasingNormalizeVisitor());

            var literalExpression = result as LiteralExpression;

            if (literalExpression == null)
                throw new InvalidOperationException();

            return literalExpression.Value;
        }
    }
}

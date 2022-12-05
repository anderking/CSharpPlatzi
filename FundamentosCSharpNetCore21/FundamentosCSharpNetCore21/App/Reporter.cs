using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FundamentosCSharpNetCore21.Entities;
using static FundamentosCSharpNetCore21.Entities.KeyDictionary;

namespace FundamentosCSharpNetCore21.App
{
      class Reporter
      {
            Dictionary<KeysDictionary, IEnumerable<PropertyBase>> _dictionary;
            public Reporter(Dictionary<KeysDictionary, IEnumerable<PropertyBase>> arg)
            {
                  if (arg == null) throw new ArgumentNullException(nameof(arg));
                  _dictionary = arg;
            }

            public IEnumerable<Evaluation> GetListEvaluations()
            {
                  if (_dictionary.TryGetValue(KeysDictionary.Evaluation, out IEnumerable<PropertyBase> list))
                  {
                        return list.Cast<Evaluation>();
                  }
                  {
                        return new List<Evaluation>();
                  }
            }

            public IEnumerable<string> GetListSubject()
            {
                  return GetListSubject(out var dummy);
            }

            public IEnumerable<string> GetListSubject(out IEnumerable<Evaluation> listEvaluations)
            {
                  listEvaluations = GetListEvaluations();

                  return (from Evaluation ev in listEvaluations select ev.Subject.Name).Distinct();
            }

            public Dictionary<string, IEnumerable<Evaluation>> GetDictionaryEvaluationBySubject()
            {
                  var result = new Dictionary<string, IEnumerable<Evaluation>>();

                  var listSubject = GetListSubject(out var listEval);

                  foreach (var subject in listSubject)
                  {
                        var dict = from Evaluation eval in listEval where eval.Subject.Name == subject select eval;

                        result.Add(subject, dict);
                  }

                  return result;
            }

            public Dictionary<string, IEnumerable<object>> GetCoverageBySubject()
            {
                  var result = new Dictionary<string, IEnumerable<object>>();
                  var dicEvaluationsBySubjects = GetDictionaryEvaluationBySubject();

                  foreach (var item in dicEvaluationsBySubjects)
                  {
                        var promsAlumn = from Evaluation eval in item.Value
                                         group eval by new
                                         {
                                               eval.Student.Id,
                                               eval.Student.Name
                                         }
                                         into groupEvaluationByStudent
                                         select new StudentCoverage
                                         {
                                               StudentId = groupEvaluationByStudent.Key.Id,
                                               StudentName = groupEvaluationByStudent.Key.Name,
                                               Coverage = groupEvaluationByStudent.Average(evaluacion => evaluacion.Note)
                                         };
                        result.Add(item.Key, promsAlumn);
                  }

                  return result;
            }

            public Dictionary<string, IEnumerable<object>> GetChallange(int max)
            {
                  var result = new Dictionary<string, IEnumerable<object>>();
                  var dictResult = GetCoverageBySubject();

                  foreach (var item in dictResult)
                  {
                        var lista = item.Value.ToList().OrderByDescending(o => ((StudentCoverage)o).Coverage).ToList();
                        lista = lista.Take(max).ToList();
                        result.Add(item.Key, lista);
                  }

                  return result;
            }
      }
}

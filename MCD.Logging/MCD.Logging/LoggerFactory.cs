using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MCD.Logging
{

    /*
    public static ILog GetLogger(string repository, string name);
    public static ILog GetLogger(Assembly repositoryAssembly, Type type);
    public static ILog GetLogger(string repository, Type type);
    public static ILog GetLogger(Type type);
    public static ILog GetLogger(Assembly repositoryAssembly, string name);
    */

    public class LoggerFactory
    {
        private XmlDocument log4netXmlConfig;
        private XmlElement log4netXmlConfigElement;

        public LoggerFactory(string configFile = "log4net.config")
        {
            using (FileStream openedConfig = File.OpenRead(configFile)) {
                log4netXmlConfig = new XmlDocument();
                log4netXmlConfig.Load(File.OpenRead("log4net.config"));
                log4netXmlConfigElement = log4netXmlConfig["log4net"];
            }
        }

        private void ConfigureRepo(ILoggerRepository loggerRepository) {
            log4net.Config.XmlConfigurator.Configure(loggerRepository, log4netXmlConfigElement);
            loggerRepository.Configured = true;
        }


        public ILog GetLogger(string repository, string name) {
            ILoggerRepository repo = LogManager.GetRepository(repository);
            if(repo == null) {
                repo = LogManager.CreateRepository(repository);
            }
            if (!repo.Configured) {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(repository, name);
        }

        public ILog GetLogger(Assembly repositoryAssembly, Type type) {
            ILoggerRepository repo = LogManager.GetRepository(repositoryAssembly);
            if (repo == null)
            {
                repo = LogManager.CreateRepository(repositoryAssembly, typeof(log4net.Repository.Hierarchy.Hierarchy));
            }
            if (!repo.Configured)
            {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(repositoryAssembly, type);
        }

        public ILog GetLogger(Assembly repositoryAssembly, string name) {
            ILoggerRepository repo = LogManager.GetRepository(repositoryAssembly);
            if (repo == null)
            {
                repo = LogManager.CreateRepository(repositoryAssembly, typeof(log4net.Repository.Hierarchy.Hierarchy));
            }
            if (!repo.Configured)
            {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(repositoryAssembly, name);
        }

        public ILog GetLogger(string repository, Type type) {
            ILoggerRepository repo = LogManager.GetRepository(repository);
            if (repo == null)
            {
                repo = LogManager.CreateRepository(repository);
            }
            if (!repo.Configured)
            {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(repository, type);
        }

        public ILog GetLogger(Type type) {
            ILoggerRepository repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            if (repo == null)
            {
                repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            }
            if (!repo.Configured)
            {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(Assembly.GetEntryAssembly(), type);
        }

        public ILog GetLogger()
        {

            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();

            ILoggerRepository repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            if (repo == null)
            {
                repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            }
            if (!repo.Configured)
            {
                ConfigureRepo(repo);
            }
            return LogManager.GetLogger(Assembly.GetEntryAssembly(), methodBase.DeclaringType);
        }


    }
}

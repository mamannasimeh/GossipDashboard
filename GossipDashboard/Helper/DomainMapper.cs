using AutoMapper;
using GossipDashboard.Models;
using GossipDashboard.ViewModel;
using System;


public sealed class DomainMapper
{
    private static volatile DomainMapper instance;
    private static readonly object syncRoot = new Object();

    private DomainMapper()
    {
        Mapper.Initialize(cfg =>
        {
            cfg.ValidateInlineMaps = false;

            cfg.CreateMap<Post, VM_Post>().ConvertUsing<M2VM_Post_Converter>();
            cfg.CreateMap<VM_Post, Post>().ConvertUsing<VM2M_Post_Converter>();
        });

        Mapper.AssertConfigurationIsValid();
    }

    public static DomainMapper Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new DomainMapper();
                }
            }

            return instance;
        }
    }
}

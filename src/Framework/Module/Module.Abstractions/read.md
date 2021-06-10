# 说明
Module.Abstractions: Module化抽象
作用：
	用于创建接口,集合

IModuleAssemblyDescriptor: 模块化程序集描述,DDD分层的时候来加载使用
IModuleDescriptor：描述
IModuleCollection：IModuleDescriptor和集合，拥有一个加载集合的方法
ModuleCollectionAbstract:模块化集合抽象化,用来加载程序集
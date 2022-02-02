namespace test

namespace test

module Models = 
    open System

    type UniqueId = Guid

    type Client = {
        Id : UniqueId
        Name : string
    }


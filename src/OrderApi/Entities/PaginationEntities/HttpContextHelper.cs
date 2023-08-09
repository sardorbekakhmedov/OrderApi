﻿namespace OrderApi.Entities.PaginationEntities;

public class HttpContextHelper
{
    private readonly HttpContext? _context;

    public HttpContextHelper(IHttpContextAccessor accessor)
    {
        _context = accessor.HttpContext;
    }

    public void AddResponseHeader(string key, string value)
    {
        if (_context is null) return;

        if(_context.Response.Headers.Keys.Contains(key))
            _context.Response.Headers.Remove(key);

        _context.Response.Headers.Add("Access-Control-Expose-Headers", key);
        _context.Response.Headers.Add(key, value);
    }
}
using System.Collections.Generic;

public interface IdatabaseReposity<T> {
    public IEnumerable<T> Read(int limit);
    public void Store(T record);
}
namespace com.emad.game.tests
{
    using UnityEngine;
    using NUnit.Framework;

    public class ObjectPoolTest
    {
        private ObjectPool<Type1> _type1Pool;

        private class Type1 : MonoBehaviour { }
        private class Type2 : MonoBehaviour { }

        [SetUp]
        public void SetUp()
        {
            _type1Pool = ObjectPool<Type1>.Instance;
            Assert.AreEqual(0, _type1Pool.PoolSize);
            _type1Pool.Load();
        }

        [Test]
        public void InstanceTest()
        {
            Assert.IsNotNull(_type1Pool);
            Assert.AreEqual(_type1Pool, ObjectPool<Type1>.Instance);

            ObjectPool<Type2> _type2Pool = ObjectPool<Type2>.Instance;
            Assert.AreNotEqual(_type1Pool, _type2Pool);
        }
        
        [Test]
        public void PoolSizeTest()
        {
            int defaultPoolSize = ObjectPool<Type1>.DEFAULT_POOL_SIZE;

            Assert.AreEqual(defaultPoolSize, _type1Pool.PoolSize);
            Type1 acquiredObject = _type1Pool.AcquireObject();
            Assert.AreEqual(defaultPoolSize-1, _type1Pool.PoolSize);
            _type1Pool.ReleaseObject(acquiredObject);
            Assert.AreEqual(defaultPoolSize, _type1Pool.PoolSize);

        }

        [Test]
        public void AcquireObjectTest()
        {
            Type1 type1Object = _type1Pool.AcquireObject();
            Assert.IsNotNull(type1Object);
            Assert.IsTrue(type1Object.GetType() == typeof(Type1));
        }

        [Test]
        public void ReleaseObjectTest()
        {
            Type1 type1Object = _type1Pool.AcquireObject();
            _type1Pool.ReleaseObject(type1Object);
            Assert.AreEqual(false, type1Object.gameObject.activeInHierarchy);
        }

        [TearDown]
        public void TearDown()
        {
            _type1Pool.Clear();
        }
    }

}
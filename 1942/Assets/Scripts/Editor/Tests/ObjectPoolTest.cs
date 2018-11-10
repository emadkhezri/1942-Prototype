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

        }

        [Test]
        public void InstanceTest()
        {
            _type1Pool = ObjectPool<Type1>.Instance;
            Assert.IsNotNull(_type1Pool);
            Assert.AreEqual(_type1Pool, ObjectPool<Type1>.Instance);

            ObjectPool<Type2> _type2Pool = ObjectPool<Type2>.Instance;
            Assert.AreNotEqual(_type1Pool, _type2Pool);
        }

        [Test]
        public void PoolSizeTest()
        {
            ObjectPool<Type1>.PoolSize = 20;
            Assert.AreEqual(20, ObjectPool<Type1>.PoolSize);
            _type1Pool = ObjectPool<Type1>.Instance;
            Assert.AreEqual(20, ObjectPool<Type1>.PoolSize);
        }

        [Test]
        public void AcquireObjectTest()
        {
            _type1Pool = ObjectPool<Type1>.Instance;
            Type1 type1Object = _type1Pool.AcquireObject();
            Assert.IsNotNull(type1Object);
            Assert.IsTrue(type1Object.GetType() == typeof(Type1));
        }

        [Test]
        public void ReleaseObjectTest()
        {
            _type1Pool = ObjectPool<Type1>.Instance;
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